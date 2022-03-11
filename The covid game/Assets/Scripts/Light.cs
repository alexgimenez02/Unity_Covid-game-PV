using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public int rotationScale = 10;
    public int mission_complete;
    public MissionWaypoint mw;

    private bool target1 = false;
    private bool target2 = false;
    private bool target3 = false;

    IEnumerator UsingYield(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Dormir");
    }

    // Update is called once per frame
    void Update()
    {
        mission_complete = mw.getGoalsAchived();
        if (mission_complete == 1)
        {

            if (!target1)
            {
                transform.Rotate(20, 0, 0);
                target1 = !target1;
            }
        }
        if (mission_complete == 2)
        {
            if (!target2)
            {
                transform.Rotate(20, -30, 0);
                target2 = !target2;
            }
        }
        if (mission_complete == 3)
        {
            if (!target3)
            {
                transform.Rotate(50, 0, 0);
                target3 = !target3;
                StartCoroutine(UsingYield(5));
            }
        }
    }
}
