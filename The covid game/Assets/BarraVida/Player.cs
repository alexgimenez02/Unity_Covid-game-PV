using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float maxHealth = 100f;
	public float currentHealth;
	public float maxProtection = 100f;
	public float currentProtection;

	public HealthBar healthBar;
	public ProtectionBar procBar;
	public Gel gel;
	public Mascarilla mascarillaPapel;
	public Mascarilla mascarillaPlastico;
	public Mascarilla mascarillaFibra;
	public GameObject person;
	
	private Vector3 prev_position;
	private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
		
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		procBar.SetMaxProtection(maxProtection);
		
		mascarillaPapel.numMasks();
		mascarillaPlastico.numMasks();	
		mascarillaFibra.numMasks();
		currentProtection = 20; 
		transform = person.transform;
		gel.setUnidades(2); 
		
    }
	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{

			//Application.LoadLevel("Game over");
			//Hacer sleep
			//Application.LoadLevel("Main menu");
			Debug.Log("Hp = 0");

		}
		else
		{
			if (prev_position == null)
			{
				prev_position = transform.position;
			}

			if (currentProtection > 0)
			{
				LossProtection(Time.deltaTime);
			}
			else
			{
				TakeDamage(Time.deltaTime + Mathf.Abs((prev_position.x - transform.position.x) + (prev_position.y - transform.position.y) + (prev_position.y - transform.position.y)));
			}
			prev_position = transform.position;



			if(Input.GetKeyDown(KeyCode.Alpha1)){
				if(mascarillaPapel.lossMascarilla()){
					currentProtection = mascarillaPapel.getProtection();
					procBar.SetProtection(currentProtection);
				}
			} else if(Input.GetKeyDown(KeyCode.Alpha2)){
				if(mascarillaPlastico.lossMascarilla()){
					currentProtection = mascarillaPlastico.getProtection();
					procBar.SetProtection(currentProtection);
				}
			} else if(Input.GetKeyDown(KeyCode.Alpha3)){
				if(mascarillaFibra.lossMascarilla()){
					currentProtection = mascarillaFibra.getProtection();
					procBar.SetProtection(currentProtection);
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if(gel.quitarUnidades())
					currentProtection += 15f;
			}
		}
	}
	void TakeDamage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
	void LossProtection(float damage)
	{
		currentProtection -= damage;

		procBar.SetProtection(currentProtection);
	}
}
