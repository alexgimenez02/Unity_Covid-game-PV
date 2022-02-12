using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBike : MonoBehaviour
{
	private float speed = 5.0f;
	public GameObject character;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += -transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0, -40f, 0) * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0, 40f, 0) * Time.deltaTime);
		}
	}
}
