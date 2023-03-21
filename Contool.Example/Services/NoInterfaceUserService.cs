namespace Contool.Example.Services;

[SingletonService]
public class NoInterfaceUserService
{
    public List<string> GetAll()
    {
        return new List<string>()
        {
            "Kakashi NoInterface",
            "Naruto NoInterface",
            "Sasuke NoInterface"
        };
    }
}
