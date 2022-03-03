using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public int rotationScale = 10;
    public int mission_complete;
    public Mission_Waypoint mw;

    // Update is called once per frame
    void Update()
    {
        mission_complete = mw.getGoalsAchived();
        if (mission_complete == 1) transform.Rotate(80, -30, 0);
        if (mission_complete == 2) transform.Rotate(120, -30, 0);
        if (mission_complete == 3) transform.Rotate(170, -30, 0);
    }
}
