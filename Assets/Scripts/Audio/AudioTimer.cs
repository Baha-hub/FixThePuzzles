using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTimer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    private void Update()
    {
        if (!ActiveGame.soundsOn)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
}
