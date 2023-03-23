namespace Contool.Example.Services;

public interface IUserRepository
{
    List<string> GetAll();
}

public class UserRepository : IUserRepository
{
    public List<string> GetAll()
    {
        return new List<string>()
        {
            "Kakashi Repository",
            "Naruto Repository",
            "Sasuke Repository"
        };
    }
}
