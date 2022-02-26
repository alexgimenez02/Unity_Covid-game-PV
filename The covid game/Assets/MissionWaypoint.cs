using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public RawImage img;
    // The target (location, enemy, etc..)
    public Transform target;

    public Text text;


    // Start is called before the first frame update
    void Start()
    {
       
        text.text = "********************************************************";

    }

    // Update is called once per frame
    void Update()
    {
        //guardamos los margenes de la pantalla que vemos
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        //var temporal para guardar de 3d a coordenadas 2d
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        //Check if the target is behind us, to only show the icon once the target is in front
        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            // Check if the target is on the left side of the screen
            if (pos.x < Screen.width / 2)
            {
                // Place it on the right (Since it's behind the player, it's the opposite)
                pos.x = maxX;
            }
            else
            {
                // Place it on the left side
                pos.x = minX;
            }
        }

        //limitamos a que la flecha solo pueda estar dentro de la pantalla para verla en todo momento
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Update the marker's position
        img.transform.position = pos;
        //Debug.Log(((int)Vector3.Distance(target.position, transform.position)).ToString() + "m");
        text.color = Color.white;
        text.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
       
    }
}
