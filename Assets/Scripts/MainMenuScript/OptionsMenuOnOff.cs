using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuOnOff : MonoBehaviour
{
    public GameObject optionsMenu;
    public void OnOffOptions(){
        if(optionsMenu.activeSelf==true){
            optionsMenu.SetActive(false);
        }else{
            optionsMenu.SetActive(true);
        }
    }
}
