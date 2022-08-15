using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsLanguageSelect : MonoBehaviour
{
    public GameObject languageTr,languageEn;
    private void Start()
    {
        ButtonSeen();
    }
    public void ChooseEn(){
        ActiveGame.en=false;
        ActiveGame.tr=true;
        SaveSystem.Save();
        ButtonSeen();
    }
    public void ChooseTr(){
        ActiveGame.tr=false;
        ActiveGame.en=true;
        SaveSystem.Save();
        ButtonSeen();
    }
    private void ButtonSeen(){
        if (ActiveGame.en==true){
            languageTr.SetActive(false);
            languageEn.SetActive(true);
        }else if(ActiveGame.tr==true){
            languageTr.SetActive(true);
            languageEn.SetActive(false);
        }
    }
}
