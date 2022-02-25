using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public RawImage img;
    // The target (location, enemy, etc..)
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        img.transform.position = Camera.main.WorldToScreenPoint(target.position);
    }
}
