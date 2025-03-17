using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public string playerName;
    public string topPlayerName;
    public int topScore;
    public int score;
    public static DataManager Instance;
          
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    
    Load();
    } 

    [System.Serializable]
    class SaveData
    {   
       public string top1;
       public int score1;

    }

    public void Save()
    {
        SaveData data = new SaveData();

        data.top1   = DataManager.Instance.playerName;
        data.score1 = DataManager.Instance.score;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayerName = data.top1;
            topScore = data.score1;

        }
    }
  

}
