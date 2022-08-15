using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaButtons : MonoBehaviour
{
    public void OpenPatreon()
    {
        Application.OpenURL("https://www.patreon.com/onepointfive?fan_landing=true");
    }
    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/One_PointFive");
    }
    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/one_pointfive/");
    }
}
