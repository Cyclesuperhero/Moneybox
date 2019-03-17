
using Moneybox.Domain;
using Moneybox.Services;
using System;

namespace Moneybox.App.Features
{
    public class WithdrawMoney
    {

        private IAccountService _accountService;
        private IAccountMessenger accountMessenger;

        public WithdrawMoney(IAccountService accountService,  IAccountMessenger accountMessenger)
        {
            this._accountService = accountService;            
            this.accountMessenger = accountMessenger;            
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {            
            try
            {
                Account account = _accountService.AccountRepository.GetAccountById(fromAccountId);
                //subscribe
                account.LowFundsReached += accountMessenger.OnLowFundsReached;
                account.SubtractMoney(amount);
                _accountService.AccountRepository.Update(account);
            }
            catch (InsufficientTransferFundsException ex)
            {
                //log ex & handle this
            }
            catch(Exception ex)
            {
                //log ex & handle this.
            }
        }
    }
}
