﻿using System.Collections;
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
	public GameObject person;
	private Vector3 prev_position;
	private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		procBar.SetMaxProtection(maxProtection);
		currentProtection = 20f;
		transform = person.transform;
    }

	// Update is called once per frame
	void Update()
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