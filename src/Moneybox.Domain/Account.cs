using System;

namespace Moneybox.Domain
{
    public class Account
    {
        private decimal _balance;

        public const decimal PayInLimit = 4000m;
        public const decimal Lowfunds = 500m;

        public delegate void LowFundsEventHandler(object sender, AccountEventArgs e);
        public delegate void AccountPayinLimitReachedEventHandler(object sender, AccountEventArgs e);
        public event LowFundsEventHandler LowFundsReached;
        public event AccountPayinLimitReachedEventHandler PayinLimitReached;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; private set; } 

        public decimal Withdrawn {
            get; private set;
        }
        public decimal PaidIn
        {
            get; private set;
        }

        public void SubtractMoney(decimal amount)
        {
            if (Balance <= 0m)
                throw new InsufficientTransferFundsException();
            else
            {
                Balance -= amount;
                Withdrawn = amount;
            }

            if (Balance <= Lowfunds)
                OnLowFundsReached();
        }

     

        public void AddMoney(decimal amount)
        {
            if ((Balance += amount) > PayInLimit)
            {
                OnAccountPayinLimitReached();
                throw new AccountPayinLimitReachedException();
            }
            else
            {
                Balance += amount;
                PaidIn = amount;

            }
        }

        protected virtual void OnLowFundsReached()
        {
            if (LowFundsReached != null)
            {
                LowFundsReached(this, new AccountEventArgs() { User = this.User });
            }
        }

        protected virtual void OnAccountPayinLimitReached()
        {
            if (PayinLimitReached != null)
            {
                PayinLimitReached(this, new AccountEventArgs() { User = this.User });
            }
        }

     
    }
}
