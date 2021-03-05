// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pole.ReliableMessage.Core.Abstraction
{
    public interface IMessageRepublishVerifierCallback
    {
    }
    public interface IMessageRepublishVerifierCallback<TMessage, TCallbackParemeter> : IMessageRepublishVerifierCallback
    {
        Task<bool> ShouldRepublish(TCallbackParemeter callbackParemeter);
    }
}
