using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI : MonoBehaviour
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
	public UI_Shop shop;
	
	private Vector3 prev_position;
	private Transform transform;
	private bool toggleShop;
    // Start is called before the first frame update
    void Start()
    {
		
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		procBar.SetMaxProtection(maxProtection);
		
		mascarillaPapel.numMasks();
		mascarillaPlastico.numMasks();	
		mascarillaFibra.numMasks();
		transform = person.transform;
		gel.setUnidades(2); 
		shop.Initialize();
		toggleShop = false;
		
    }
	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{

			//Application.LoadLevel("Game over");
			//Hacer sleep
			//Application.LoadLevel("Main menu");
			if(currentHealth < 0) currentHealth = 0;

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
				if(currentProtection < 0) currentProtection = 0;
			}
			else
			{
				TakeDamage(Time.deltaTime + Mathf.Abs((prev_position.x - transform.position.x) + (prev_position.y - transform.position.y) + (prev_position.y - transform.position.y)));
			}
			prev_position = transform.position;



			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				if(!(currentProtection == maxProtection)){
					if(currentProtection < mascarillaPapel.getProtection()){
						if(mascarillaPapel.lossMascarilla()){
							currentProtection = mascarillaPapel.getProtection();
							if(currentProtection > maxProtection) currentProtection = maxProtection;
						}
					}
				}
			} else if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				if(!(currentProtection == maxProtection)){
					if(currentProtection < mascarillaPlastico.getProtection()){
						if(mascarillaPlastico.lossMascarilla()){
							currentProtection = mascarillaPlastico.getProtection();
							if(currentProtection > maxProtection) currentProtection = maxProtection;
						}
					}
				}
			} else if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				if(!(currentProtection == maxProtection)){
					if(currentProtection < mascarillaFibra.getProtection()){
						if(mascarillaFibra.lossMascarilla()){
							currentProtection = mascarillaFibra.getProtection();
							if(currentProtection > maxProtection) currentProtection = maxProtection;
						}
					}
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if(!(currentProtection == maxProtection)){
				if(gel.quitarUnidades())
					currentProtection += 15f;
					if(currentProtection > maxProtection) currentProtection = maxProtection;
				}
			}
			else if (Input.GetKeyDown(KeyCode.E)){ 
				toggleShop = !toggleShop;
			}
			if(toggleShop){
				if(Time.timeScale == 1.0)
					Time.timeScale = 0.0f;
				shop.Awake();
			}else if(!toggleShop){
				if(Time.timeScale == 0.0)
					Time.timeScale = 1.0f;
				shop.SleepShop();
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
