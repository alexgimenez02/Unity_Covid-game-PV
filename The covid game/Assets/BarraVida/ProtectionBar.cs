using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionBar : MonoBehaviour
{

	public Slider slider;
	

	public void SetMaxProtection(float health)
	{
		slider.maxValue = health;
		slider.value = health;

	}

	public void SetProtection(float health)
	{
		slider.value = health;

	}
	public float GetProtection()
    {
		return slider.value;
    }

}
