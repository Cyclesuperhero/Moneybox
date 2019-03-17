using System;
using Moneybox.Domain;

namespace Moneybox.DataAccess
{
    public interface IAccountRepository
    {
        Account GetAccountById(Guid accountId);

        void Update(Account account);
    }
}
