using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundOnOff : MonoBehaviour
{
    public GameObject soundsOn, soundsOff, musicOn, musicOff;
    public void MusicOn(){
        ActiveGame.musicOn=true;
        SaveSystem.Save();
    }
    public void MusicOff(){
        ActiveGame.musicOn=false;
        SaveSystem.Save();
    }
    public void SoundsOn(){
        ActiveGame.soundsOn=true;
        SaveSystem.Save();
    }
    public void SoundsOff(){
        ActiveGame.soundsOn=false;
        SaveSystem.Save();
    }
    private void Start()
    {
        if (ActiveGame.soundsOn)
        {
            soundsOff.SetActive(false);
            soundsOn.SetActive(true);
        }else if (!ActiveGame.soundsOn)
        {
            soundsOff.SetActive(true);
            soundsOn.SetActive(false);
        }
        if (ActiveGame.musicOn)
        {
            musicOff.SetActive(false);
            musicOn.SetActive(true);
        }
        else if (!ActiveGame.musicOn)
        {
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
    }
}
