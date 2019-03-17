using System;
using System.Collections.Generic;
using System.Text;

namespace Moneybox.Domain
{
    public class AccountEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
