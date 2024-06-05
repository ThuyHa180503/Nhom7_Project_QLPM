using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom7_Project_QLPM.Class
{
    internal class UserSession
    {
        public static string AccountId { get; private set; }
        public static string ChucVu { get; private set; }

        public static void StartSession(string accountId, string chucVu)
        {
            AccountId = accountId;
            ChucVu = chucVu;
        }

        public static void EndSession()
        {
            AccountId = null;
            ChucVu = null;
        }

        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(AccountId);
        }
    }
}
