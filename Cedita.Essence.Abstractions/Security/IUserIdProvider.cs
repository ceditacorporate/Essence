namespace Cedita.Essence.Abstractions.Security
{
    public interface IUserIdProvider
    {
        bool HasCurrentUser();
        object GetCurrentUserId();
    }
}
