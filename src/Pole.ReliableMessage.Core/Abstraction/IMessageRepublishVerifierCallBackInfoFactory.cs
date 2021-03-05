// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Pole.ReliableMessage.Core.Messaging.CallBack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pole.ReliableMessage.Core.Abstraction
{
    public interface IMessageRepublishVerifierCallBackInfoFactory
    {
        MessageRePublishVerifierCallBackInfo Generate(Type eventHandlerType);
    }
}
