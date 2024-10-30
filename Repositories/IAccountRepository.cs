using BusinessObjects;

namespace Repositories
{
    public interface IAccountRepository
    {
        AccountMember? GetAccountMemberById(string memberid);

    }
}