using Moneybox.Domain;

namespace Moneybox.App.Features
{
    public interface IAccountMessenger
    {
        void OnAccountLimitApproaching(object sender, AccountEventArgs e);
        void OnLowFundsReached(object sender, AccountEventArgs e);
    }
}