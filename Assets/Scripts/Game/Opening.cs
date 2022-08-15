using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject objects;
    void Start()
    {
        StartCoroutine(WaitForOpening());
    }
    IEnumerator WaitForOpening()
    {
        yield return new WaitForSeconds(1.4f);
        gameObject.SetActive(false);
        objects.SetActive(true);
    }
}
