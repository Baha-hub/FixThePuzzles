using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{

    // MainMenudeki levellara tıklandığında hangi level'ın açılacağını belirliyor.
    // bu metodu tüm butonlara atıp içlerine sadece 1-2-3 şeklinde hangi level açılmasını istiyorsak onu yazarak kullanabiliriz.
    public int scene=0;

    // tüm levelların adı "Level_" şeklinde başlıyor ve kodun kullanıldığı yerde 1 girilirse "Level_1" olmuş oluyor ve o scene açılıyor.
    public void Open(){
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }

    // MainMenude bulunan play buttonunda kullanılacak. en son oynanılabilir olan level'ı otomatik olarak açacak.
    public void OpenLastPlayableLevel(){
        SceneManager.LoadScene(ActiveGame.lastPlayableLevel);
    }
    
}
