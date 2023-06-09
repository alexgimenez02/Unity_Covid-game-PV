using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;       //Public variable to store a reference to the player game object
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    public float turnSpeed = 4.0f;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
	    if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
           offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        }
        else
        {
            if(Input.GetKey(KeyCode.Q))
                offset = Quaternion.AngleAxis (-1 * turnSpeed, Vector3.up) * offset;
            else if(Input.GetKey(KeyCode.R))
                offset = Quaternion.AngleAxis (1 * turnSpeed, Vector3.up) * offset;

        }
        transform.position = player.transform.position + offset;
        transform.LookAt(player.position);

    }
}