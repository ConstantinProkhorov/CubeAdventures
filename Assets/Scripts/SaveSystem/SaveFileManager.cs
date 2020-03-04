using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveFileManager
{
    private static string Path
    {
        get
        { return Application.persistentDataPath + "player1.tsf"; }
    } 
    public static void Save(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData Load()
    {
        if (File.Exists(Path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            PlayerData data = FirstLoad();
            return data;
        }
    }
    public static PlayerData FirstLoad()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path, FileMode.Create);
        PlayerData data = new PlayerData();
        formatter.Serialize(stream, data);
        stream.Close();
        return data;
    }
}
