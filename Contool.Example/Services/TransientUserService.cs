namespace Contool.Example.Services;

public interface ITransientUserService
{
    List<string> GetAll();
}

[TransientService]
public class TransientUserService : ITransientUserService
{
    public List<string> GetAll()
    {
        return new List<string>()
        {
            "Kakashi Transient",
            "Naruto Transient",
            "Sasuke Transient"
        };
    }
}
