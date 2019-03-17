using Moneybox.Domain;
using Moneybox.Services;
using System;
using System.Transactions;

namespace Moneybox.App.Features
{
    public class TransferMoney
    {
        private IAccountService _accountService;
        
        private IAccountMessenger _accountMessenger;

        public TransferMoney(IAccountService accountService, IAccountMessenger accountMessenger)
        {
            this._accountService = accountService;          
            _accountMessenger = accountMessenger;
            
        }

        public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
        {

            try
            {
                Account fromAccount = this._accountService.AccountRepository.GetAccountById(fromAccountId);
                Account toAccount = this._accountService.AccountRepository.GetAccountById(toAccountId);

                //subscribe events
                fromAccount.LowFundsReached += _accountMessenger.OnLowFundsReached;
                toAccount.PayinLimitReached += _accountMessenger.OnAccountLimitApproaching;


                using (TransactionScope scope = new TransactionScope())
                {
                    //need to make transfer atomic, can't pay in from one if other won't allow withdrawl
                    //will rollback if fail
                    fromAccount.SubtractMoney(amount);
                    toAccount.AddMoney(amount);
                    this._accountService.AccountRepository.Update(fromAccount);
                    this._accountService.AccountRepository.Update(toAccount);
                    scope.Complete();
                }
            }
            catch(InsufficientTransferFundsException ex)
            {
                //log ex & handle this
            }
            catch (AccountPayinLimitReachedException ex)
            {
                //log ex & handle this
            }
            catch (Exception ex)
            {
                //log ex & handle this
            }
        }
    }
}
