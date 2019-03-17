using System;
using System.Collections.Generic;
using System.Text;

namespace Moneybox.Domain
{
    public class InsufficientTransferFundsException : Exception
    {
        public override string Message => "Insufficient funds to make transfer";
    }
}
