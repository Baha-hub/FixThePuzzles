using GooglePlayGames.BasicApi.Multiplayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour

{
    public static int tempStarAmount = 0;
    public static bool isLevelFinished = false;
    public static bool isEditable = true;
    public static bool isStartable = true;
    public static GameObject lastClicked;
    public static int usedItemAmount = 0;
    public static bool beenEditable = false;
    public void Start()
    {
        Time.timeScale = 1.0f;
        if (PlayerPrefs.GetInt("") == 0)
        {
            PlayerPrefs.SetInt("", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else if (PlayerPrefs.GetInt("") == 1)
        {
            PlayerPrefs.SetInt("", 0);

        }

        Time.timeScale = 1.0f;
        PanZoom.zoomOutMax =14;
        for(int i = 0; i < 1000; i++)
        {
            PanZoom.zoom(-0.1f);
        }
        StartCoroutine(Delay());
    }
    public void Update()
    {
        if (isEditable)
        {
            if (PanZoom.zoomOutMax == 14)
            {
                PanZoom.zoom(-0.1f);
            }
            else
                PanZoom.zoom(+0.1f);

        }
        else
        {
            PanZoom.zoom(-0.1f);

        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        PanZoom.zoomOutMax = 8;
    }
}
