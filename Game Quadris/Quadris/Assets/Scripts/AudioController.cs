using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public Slider master;
    public Slider music;
    public Slider sfx;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMasterSound(float vol){
        mixer.SetFloat("MasterVol", Mathf.Log10(vol) * 20);
    }

    public void setMusicSound(float vol){
        mixer.SetFloat("MusicVol", Mathf.Log10(vol) * 20);
    }
    
    public void setSFXSound(float vol){
        mixer.SetFloat("SFXVol", Mathf.Log10(vol) * 20);
    }
}
