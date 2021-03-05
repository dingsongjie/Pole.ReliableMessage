// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Pole.ReliableMessage.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pole.ReliableMessage.Core.Messaging.CallBack
{
    class DefaultRepublishCallBackFinder : IRepublishCallBackFinder
    {
        public List<Type> FindAll(IEnumerable<Assembly> assemblies)
        {
            var callbackType = typeof(IMessageRepublishVerifierCallback);

            var callbackTypes = assemblies.SelectMany(m => m.GetTypes().Where(type => callbackType.IsAssignableFrom(type)));
            return callbackTypes.ToList();
        }
    }
}
