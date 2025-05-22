using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/save.dat";

    public static void Save(PlayerState playerState, int nbPressed)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData
        {
            coins = playerState.coins,
            food = playerState.food,
            lvl = playerState.lvl,
            biomeKelp = playerState.BiomeKelp,
            biomeEpave = playerState.BiomeEpave,
            nbPressed = nbPressed
        };

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Fichier de sauvegarde introuvable.");
            return null;
        }
    }

    public static void DeleteSave()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}