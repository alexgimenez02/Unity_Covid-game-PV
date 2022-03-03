using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public int rotationScale = 10;
    public bool mission_complete = false;

    // Update is called once per frame
    void Update()
    {
        if (mission_complete) transform.Rotate(230, -30, 0);
    }
}
