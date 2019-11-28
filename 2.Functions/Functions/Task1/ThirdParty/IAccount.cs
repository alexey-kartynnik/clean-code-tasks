using System;
using System.Collections.Generic;

namespace Functions.Task1.ThirdParty
{
    public interface IAccount
    {
        string GetName();

        string GetPassword();

        void SetCreatedDate(DateTime date);

        IAddress GetAdditionalAddress();

        IAddress GetWorkAddress();

        IAddress GetHomeAddress();

        void SetAddresses(IList<IAddress> addresses);
    }
}