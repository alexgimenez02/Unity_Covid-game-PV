using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject Persona;
	Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
		Persona = GetComponent<Bicycle>();
        direccion = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.y++;
    }
}
