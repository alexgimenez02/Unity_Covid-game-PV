using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    /*void Update()
    {
	if (Input.GetKey(KeyCode.LeftArrow))
	{
		transform.Rotate(new Vector3(0, -40f, 0) * Time.deltaTime);
	}
	if (Input.GetKey(KeyCode.RightArrow))
	{
		transform.Rotate(new Vector3(0, 40f, 0) * Time.deltaTime);
		tranform.position += (0, 40f, 0) * speed * Time.deltaTime; 
	}
    }*/

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}