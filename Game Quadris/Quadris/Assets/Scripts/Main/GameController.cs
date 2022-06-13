using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Data persisted between scenes
    public static PlayerData playerData;
    public int currentLevel;

    void Awake()
    {
        playerData = SaveAndLoad.Load();
        print("Data Path: " + Application.persistentDataPath);
        currentLevel = playerData.currentLevel;
    }

    public void ClearProgress()
    {
        playerData = SaveAndLoad.Clear();
    }

    public void incrementCurrentLevel(int level)
    {
        if(level >= playerData.currentLevel)
        {
            playerData.currentLevel++;
            SaveAndLoad.Save();
        }
    }
}
