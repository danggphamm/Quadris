using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{
    public GameObject gameController;
    private string[] sceneNames;
    private ArrayList extraNames = new ArrayList();

    void Start()
    {
        sceneNames = new string[100];
        sceneNames[0] = "Tutorial 1";
        sceneNames[1] = "Tutorial 2";
        sceneNames[2] = "Tutorial 3";

        sceneNames[3] = "Level 1-1";
        sceneNames[4] = "Level 1-2";
        sceneNames[5] = "Level 1-3";

        sceneNames[6] = "Level 2-1";
        sceneNames[7] = "Level 2-2";
        sceneNames[8] = "Level 2-3";

        extraNames.Add("Tutorial extra");
        extraNames.Add("Set 1 extra");
        extraNames.Add("Set 2 extra");
    }

    public void changeScene(string sceneName)
    {
        if (sceneName.ToLower().Equals("start") 
            || sceneName.ToLower().Equals("main") 
            || sceneName.ToLower().Equals("options")
            || sceneName.ToLower().Equals("credits"))
        {
            SceneManager.LoadScene(sceneName);
        }

        if (gameController != null)
        {
            if(!extraNames.Contains(sceneName))
            {
                if (GameController.playerData.currentLevel >= Array.IndexOf(sceneNames, sceneName) + 1)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
            
            else
            {
                if (GameController.playerData.currentLevel >= (extraNames.IndexOf(sceneName) + 1)*3 + 1)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}
