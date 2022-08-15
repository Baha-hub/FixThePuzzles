using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScripts : MonoBehaviour
{
    public GameObject enLevelsPic,trLevelsPic;
    public Text settingsTxtSettings, settingsTxtLanguage, settingsTxtSounds, settingsTxtMusic, specialLevels,specialLevelsNeed,hints,buyhintinfo,buynoadsinfo,buyspeciallevelinfo,buypremiuminfo
                ,shoptext;
    public void MainMenuLevelsLanguage(){
        if(ActiveGame.en==true){
            enLevelsPic.SetActive(true);
            trLevelsPic.SetActive(false);
            settingsTxtSettings.text="Settings";
            settingsTxtMusic.text="Music";
            settingsTxtSounds.text="Sounds";
            settingsTxtLanguage.text="Lang";
            specialLevels.text = "Extra";
            specialLevelsNeed.text = "Need\nAdvertisement ";
            hints.text = "Hints";
            buyhintinfo.text= "Dou you want to fill your hints ? \n 300 Gold.";
            buynoadsinfo.text = "Dou you want to remove ads ? \n 900 Gold.";
            buyspeciallevelinfo.text = "Do you want to open extra levels ? \n 2000 Gold.";
            buypremiuminfo.text = "Do you want to \n-Open extra levels  -Remove ads -Fill hints.\n 2900 Gold.";
            shoptext.text = "Shop";
        }
        else{
            enLevelsPic.SetActive(false);
            trLevelsPic.SetActive(true);
            settingsTxtSettings.text="Ayarlar";
            settingsTxtMusic.text="Müzik";
            settingsTxtSounds.text="Sesler";
            settingsTxtLanguage.text="Dil";
            specialLevels.text = "Ekstra";
            specialLevelsNeed.text = "Kalan\nReklam";
            hints.text = "Ipucları";
            buyhintinfo.text = "Ipuclarını doldurmak istiyor musun ? \n 300 Altın";
            buynoadsinfo.text = "Reklamları kaldırmak istiyor musun ? \n 900 Altin.";
            buyspeciallevelinfo.text = "Ekstra bolumleri acmak istiyor musun ? \n 2000 Altin.";
            buypremiuminfo.text = "Istiyor musun ? \n-Ekstra bolumleri acmak  -Reklamları kaldırma   -Ipuclarını doldurmak.\n 2900 Altin.";
            shoptext.text = "Magaza";
        }
    }
}
