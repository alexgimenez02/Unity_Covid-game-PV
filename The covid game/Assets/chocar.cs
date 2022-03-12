using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chocar : MonoBehaviour
{
    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chocar"){
            audioSource.Play();
        }
    }
}
