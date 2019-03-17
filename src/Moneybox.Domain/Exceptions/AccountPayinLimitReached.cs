using System;
using System.Collections.Generic;
using System.Text;

namespace Moneybox.Domain
{
    public class AccountPayinLimitReachedException : Exception
    {
        public override string Message => "Account pay in limit reached";
    }
}
