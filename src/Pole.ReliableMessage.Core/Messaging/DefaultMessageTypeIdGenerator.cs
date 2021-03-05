// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Pole.ReliableMessage.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pole.ReliableMessage.Core.Messaging
{
    class DefaultMessageTypeIdGenerator : IMessageTypeIdGenerator
    {
        public string Generate(Type messageType)
        {
            return messageType.FullName;
        }
    }
}
