using Pole.ReliableMessage.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pole.ReliableMessage.Core
{
    class DefaultRetryTimeDelayCalculator : IRetryTimeDelayCalculator
    {
        public int Get(int retryTimes, int maxPendingMessageRetryDelay)
        {
            var retryTimeDelay = (int)Math.Pow(2, retryTimes + 1);
            if (retryTimeDelay >= maxPendingMessageRetryDelay)
            {
                return maxPendingMessageRetryDelay;
            }
            return retryTimeDelay;
        }
    }
}
