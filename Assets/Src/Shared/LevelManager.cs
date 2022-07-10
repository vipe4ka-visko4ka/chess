using System.IO;
using UnityEngine;
using Shared.Model;

public class LevelManager
{
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

    private readonly string _levelPath;
    private readonly string _levelFolderPath;

    public LevelManager(string levelName)
    {
        _levelFolderPath = Path.Combine(Application.dataPath, "levels");
        _levelPath = Path.Combine(_levelFolderPath, $"{levelName}.json");
    }

    public void SaveLevel(PieceInfo[] pieces)
    {
        if (!Directory.Exists(_levelFolderPath))
            Directory.CreateDirectory(_levelFolderPath);

        string jsonPieces = JsonUtility.ToJson(new Wrapper<PieceInfo>() { Items = pieces }, true);
        File.WriteAllText(_levelPath, jsonPieces);
    }

    public PieceInfo[] LoadLevel()
    {
        string data = File.ReadAllText(_levelPath);
        return JsonUtility.FromJson<Wrapper<PieceInfo>>(data).Items;
    }
}
