using Functions.Task1.ThirdParty;
using System;
using System.Collections.Generic;

namespace Functions.Task1
{
    public class RegisterAccountAction
    {
        public IPasswordChecker PasswordChecker { get; set; }
        public IAccountManager AccountManager { get; set; }

        public void Register(IAccount account)
        {
            if (account.GetName().Length <= 5)
            {
                throw new WrongAccountNameException();
            }
            string password = account.GetPassword();
            if (password.Length <= 8)
            {
                if (PasswordChecker.Validate(password) != CheckStatus.Ok)
                {
                    throw new WrongPasswordException();
                }
            }

            account.SetCreatedDate(new DateTime());
            var addresses = new List<IAddress>
            {
                account.GetHomeAddress(),
                account.GetWorkAddress(),
                account.GetAdditionalAddress()
            };
            account.SetAddresses(addresses);
            AccountManager.CreateNewAccount(account);
        }
    }
}