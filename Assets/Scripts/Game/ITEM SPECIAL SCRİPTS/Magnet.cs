using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    void Start()
    {
        foreach (ParticleSystemRenderer p in gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
        {
            p.material.shader = Shader.Find("Strike");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
