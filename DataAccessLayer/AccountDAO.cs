using BusinessObjects;
using System.Linq;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public MyStoreContext _context;
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public AccountMember? GetAccountById(string memberid)
        {
            _context = new MyStoreContext();
            return _context.AccountMembers.FirstOrDefault(a => a.MemberID.Equals(memberid));
        }
    }
}
