using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionWaypoint : MonoBehaviour
{
    public RawImage img;
    // Target locations for day one demo
    public Transform target;
    public bool target_state = false;
    public Transform target2;
    public bool target_state2 = false;
    public Transform target3;
    public bool target_state3 = false;

    public int goalsAchived;

    public Text text;
    public int distance;
    public Vector2 pos;
    private GUIStyle currentStyle;
    public bool showmessage;
    public Money money;


    // Start is called before the first frame update
    void Start()
    {
       
        text.text = "********************************************************";
        text.color = Color.white;
        goalsAchived = 0;
        showmessage = false;
        target_state = true;
        target_state2 = true;
        target_state3 = true;



    }

    // Update is called once per frame
    void Update()
    {
        if (goalsAchived < 3)
        {
            //guardamos los margenes de la pantalla que vemos
            float minX = img.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;
            float minY = img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            //var temporal para guardar de 3d a coordenadas 2d
            pos = Camera.main.WorldToScreenPoint(target.position);

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
            //write meters to arrive to target
            distance = (int)Vector3.Distance(target.position, transform.position);
            text.text = distance.ToString() + "m";

            //player reached target 3
            if (distance <= 11 && goalsAchived == 2)
            {
                goalsAchived = 3;
                showmessage = true;

            }

            //player reached target 2
            if (distance <= 11 && goalsAchived == 1)
            {
                //change target to target 2
                target = target3;
                //change goals achieved to 1;
                goalsAchived = 2;
                showmessage = true;
            }

            //player reached target 1
            if (distance <= 11 && goalsAchived == 0)
            {
                //change target to target 2
                target = target2;
                //change goals achieved to 1;
                goalsAchived = 1;
                showmessage = true;
            }


        }
        else
        {
            img.enabled = false;
        }

    }

    void OnGUI(){
        int windowWidth = 200;
        int windowHeight = 200;
        int x = (Screen.width - windowWidth) / 2;
        int y = (Screen.height - windowWidth) / 2;

        if (showmessage)
        {
           
            if (Input.GetKey(KeyCode.Return))
            {
                
                showmessage = false;
            }
        }



        if (showmessage)
        {
            //create a texture for background
            currentStyle = new GUIStyle(GUI.skin.box);
            currentStyle.normal.background = MakeTex(2, 2, Color.black);

            if(goalsAchived == 1 )
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Package 1 delivered!! \r\n You receive 30€ \r\n deliver the next package \r\n PRESS ENTER TO CONTINUE", currentStyle);
                if (target_state == true)
                {
                    money.addMoney(30);
                    target_state = false;

                }



            }
            if (goalsAchived == 2)
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Package 2 delivered!!  \r\n You receive 50€ \r\n deliver the next package \r\n PRESS ENTER TO CONTINUE", currentStyle);
                if (target_state2 == true)
                {
                    money.addMoney(50);
                    target_state2 = false;

                }
            }
            if (goalsAchived == 3)
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Package 3 delivered!! \r\n enjoy your 10€  \r\n PRESS ENTER TO CONTINUE ", currentStyle);
                if (target_state3 == true)
                {
                    money.addMoney(10);
                    target_state3 = false;

                }
            }

        }
            
        
    }
    

    
    Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
    public int getGoalsAchived()
    {
        return goalsAchived;
    }
}

