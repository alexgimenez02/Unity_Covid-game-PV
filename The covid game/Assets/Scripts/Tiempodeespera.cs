using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempodeespera : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(UsingYield(7));
    }

    IEnumerator UsingYield(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Ciudad");
    }
}


