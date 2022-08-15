using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    public static bool levelStartable;
    public static int canBeStart=0;
    bool countOnce=true,countOnce1=false;
    static bool didTwice=true,didTwice1=false;
    private void Start()
    {
        canBeStart = 0;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="LevelObjects" || other.gameObject.tag=="Ball" || other.gameObject.tag=="Untagged"){
            levelStartable = false;
            if (countOnce)
            {
                canBeStart++;
                countOnce = false;
                countOnce1 = true;
            }
        }
        else if(other.gameObject.tag == "HitBoxControl") {
            levelStartable = false;
            canBeStart++;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "LevelObjects" || other.gameObject.tag == "Ball" || other.gameObject.tag == "Untagged")
        {
            levelStartable = true;
            if (countOnce1)
            {
                canBeStart--;
                countOnce1 = false;
                countOnce = true;
            }
        }
        else if (other.gameObject.tag == "HitBoxControl")
        {
            levelStartable = true;
            canBeStart--;
        }
    }
}