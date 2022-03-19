namespace WebApi
{
    public interface IJwtAuthenticationManager
    {
        string Login(string userName, string password);
    }
}
