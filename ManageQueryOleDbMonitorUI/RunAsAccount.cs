using Microsoft.EnterpriseManagement.Security;
using System;
using System.Globalization;

namespace ManageQueryOleDbMonitorUI
{
    public class RunAsAccount
    {
        // Fields
        private Guid? accountId;

        private string accountName;
        private byte[] accountStorageIdByteArray;
        private string accountStorageIdString;

        // Methods
        internal RunAsAccount(SecureData account)
        {
            this.accountName = account.Name;
            this.accountId = account.Id;
            this.accountStorageIdByteArray = account.SecureStorageId;
            this.accountStorageIdString = string.Empty;
            foreach (byte num in this.accountStorageIdByteArray)
            {
                this.accountStorageIdString = this.accountStorageIdString + num.ToString("X2", CultureInfo.InvariantCulture);
            }
        }

        // Properties
        internal Guid? AccountId
        {
            get
            {
                return this.accountId;
            }
        }

        internal string AccountName
        {
            get
            {
                return this.accountName;
            }
        }

        internal byte[] AccountStorageIdByteArray
        {
            get
            {
                return this.accountStorageIdByteArray;
            }
        }

        internal string AccountStorageIdString
        {
            get
            {
                return this.accountStorageIdString;
            }
        }
    }
}