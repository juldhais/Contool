namespace Contool.Example.Services;

public interface ISingletonUserService
{
    List<string> GetAll();
}

[SingletonService]
public class SingletonUserService : ISingletonUserService
{
    public List<string> GetAll()
    {
        return new List<string>()
        {
            "Kakashi Singleton",
            "Naruto Singleton",
            "Sasuke Singleton"
        };
    }
}
