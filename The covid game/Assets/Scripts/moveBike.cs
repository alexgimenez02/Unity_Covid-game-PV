using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBike : MonoBehaviour
{
	private float speed = 10.0f;
	public GameObject character;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.eulerAngles = Vector3.up * transform.localEulerAngles.y;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			transform.position += -transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.Rotate(new Vector3(0, -40f, 0) * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.Rotate(new Vector3(0, 40f, 0) * Time.deltaTime);
		}
	}
}
