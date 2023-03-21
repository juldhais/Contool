namespace Contool.Example.Services;

public interface IScopedUserService
{
    List<string> GetAll();
}

[ScopedService]
public class ScopedUserService : IScopedUserService
{
    public List<string> GetAll()
    {
        return new List<string>()
        {
            "Kakashi Scoped",
            "Naruto Scoped",
            "Sasuke Scoped"
        };
    }
}
