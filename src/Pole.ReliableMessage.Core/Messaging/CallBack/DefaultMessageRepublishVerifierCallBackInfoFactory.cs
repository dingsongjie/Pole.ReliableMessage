// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Pole.ReliableMessage.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pole.ReliableMessage.Core.Messaging.CallBack
{
    class DefaultMessageRepublishVerifierCallBackInfoFactory : IMessageRepublishVerifierCallBackInfoFactory
    {
        private readonly IMessageTypeIdGenerator _messageTypeIdGenerator;
        public DefaultMessageRepublishVerifierCallBackInfoFactory(IMessageTypeIdGenerator messageTypeIdGenerator)
        {
            _messageTypeIdGenerator = messageTypeIdGenerator;
        }
        public MessageRePublishVerifierCallBackInfo Generate(Type republishCallbackType)
        {
            var @interface = republishCallbackType.GetInterfaces().FirstOrDefault();
            Func<object, object, Task<bool>> deleg = MakeCallBackFunc(republishCallbackType, @interface);

            var eventType = @interface.GetGenericArguments()[0];
            var eventCallbackArguemntType = @interface.GetGenericArguments()[1];
            var enentName = _messageTypeIdGenerator.Generate(eventType);

            MessageRePublishVerifierCallBackInfo messageCallBackInfo = new MessageRePublishVerifierCallBackInfo(enentName, deleg, republishCallbackType, eventCallbackArguemntType, eventType);
            return messageCallBackInfo;
        }

        private static Func<object, object, Task<bool>> MakeCallBackFunc(Type republishallbackType, Type @interface)
        {
            var callbackParemeterType = @interface.GetGenericArguments()[1];
            var argument = Expression.Parameter(typeof(object));
            var paremeter = Expression.Parameter(typeof(object));
            // var typedParemeter = Expression.Parameter(eventType);
            var typedcallbackParemeter = Expression.Convert(argument, callbackParemeterType);

            var typedParemeter = Expression.Convert(paremeter, republishallbackType);

            var callBackMethod = republishallbackType.GetMethod("ShouldRepublish");
            var call = Expression.Call(typedParemeter, callBackMethod, typedcallbackParemeter);

            //var innerParemeter = eventType.GetInterfaces().FirstOrDefault();
            var lambda = Expression.Lambda<Func<object, object, Task<bool>>>(call, true, argument, paremeter);
            var deleg = lambda.Compile();
            return deleg;
        }
    }
}
