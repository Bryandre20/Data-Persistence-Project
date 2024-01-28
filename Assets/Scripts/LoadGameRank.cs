using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class LoadGameRank : MonoBehaviour
{
    public Text bestPlayerName;

    private static int bestScore;
    private static string bestPlayer;

    private void Awake()
    {
        LoadGameRanking();
    }

    private void SetBestPlayer()
    {
        if (bestPlayerName == null && bestScore == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Score - {bestPlayer}:{bestScore}";
        }
    }

    public void LoadGameRanking()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.HighestPlayerName;
            bestScore = data.HighestScore;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighestScore;
        public string HighestPlayerName;
    }
}
