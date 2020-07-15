using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager
{
    public static void Save(string path, GameData gamedata)
    {
        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(fs, gamedata);
        }
    }

    public static GameData Load(string path)
    {
        using (var fs = new FileStream(path, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (GameData)formatter.Deserialize(fs);
        }
    }
}
