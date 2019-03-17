using Moneybox.Domain;
using Moneybox.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moneybox.App.Features
{
    public class AccountMessenger : IAccountMessenger
    {
        private INotificationService _notificationService;

        public AccountMessenger(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void OnAccountLimitApproaching(object sender, AccountEventArgs e)
        {
            _notificationService.NotifyApproachingPayInLimit(e.User.Email);
        }

        public void OnLowFundsReached(object sender, AccountEventArgs e)
        {
            _notificationService.NotifyFundsLow(e.User.Email);
        }
    }
}
