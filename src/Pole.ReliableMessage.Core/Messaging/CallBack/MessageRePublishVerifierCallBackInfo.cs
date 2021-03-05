// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pole.ReliableMessage.Core.Messaging.CallBack
{
    public class MessageRePublishVerifierCallBackInfo
    {
        public Func<object, object, Task<bool>> Func { get; private set; }
        public string MessageTypeId { get; private set; }
        public Type EventType { get; private set; }
        public Type EventCallbackType { get; private set; }
        public Type EventCallbackArguemntType { get; private set; }

        public MessageRePublishVerifierCallBackInfo(string messageTypeId, Func<object, object, Task<bool>> func, Type eventCallbackType, Type eventCallbackArguemntType, Type eventType)
        {
            MessageTypeId = messageTypeId;
            Func = func;
            EventCallbackType = eventCallbackType;
            EventCallbackArguemntType = eventCallbackArguemntType;
            EventType = eventType;
        }

        public Task<bool> Invoke(object parameter, object reliableEvent)
        {
            return Func(parameter, reliableEvent);
        }
    }
}
