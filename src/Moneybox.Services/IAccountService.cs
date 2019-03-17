using Moneybox.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moneybox.Services
{
    public interface IAccountService
    {
         IAccountRepository AccountRepository { get; set; }
    }
}
