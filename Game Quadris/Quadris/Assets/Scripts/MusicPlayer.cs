using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource player;
    public AudioClip musicMenu;
    public AudioClip musicSpace;
    public AudioClip musicOcean;
    public AudioClip musicDino;
    public AudioClip musicEndless;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInChildren<AudioSource>();

        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {
        //string currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log("currentScene: " + currentScene);
    }

    private void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if(objs.Length > 1){
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void changeMusic(string scene){
        //test
        /*
        switch(scene){
            case "Tutorial 1":
                player.clip = musicSpace;
                player.Play();
                break;
        }*/

        if(scene == "Main"){
            if(player.clip != musicMenu){
                player.clip = musicMenu;
                player.Play();
            }
        }
    
        if((scene == "Tutorial 1") || (scene == "Tutorial 2")
                 || (scene == "Tutorial 3") || (scene == "Tutorial extra")){
            player.clip = musicSpace;
            player.Play();
        }

        if((scene == "Level 1-1") || (scene == "Level 1-2")
                 || (scene == "Level 1-3") || (scene == "Set 1 extra")){
            player.clip = musicOcean;
            player.Play();
        }

        if((scene == "Level 2-1") || (scene == "Level 2-2")
                 || (scene == "Level 2-3") || (scene == "Set 2 extra")){
            player.clip = musicDino;
            player.Play();
        }

        if(scene == "Endless level"){
            player.clip = musicEndless;
            player.Play();
        }
    }

    private void ChangedActiveScene(Scene current, Scene next){
        string currentName = current.name;

        if (currentName == null){
            currentName = "replaced";
        }

        changeMusic(next.name);

        Debug.Log("Sceens: " + currentName + ", " + next.name);
    }
}
