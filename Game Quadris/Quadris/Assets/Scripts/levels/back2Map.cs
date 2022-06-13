using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back2Map : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
