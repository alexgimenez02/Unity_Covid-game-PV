using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public GameObject camera;
	public Money money;
	public GameObject[] pharmacyList;



	private int windowWidth, windowHeight, x, y;
	private GUIStyle currentStyle;
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
		shop.SleepShop();
		toggleShop = false;
		money.readMoney();
    }
	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			Application.LoadLevel("Game Over");
			

		}
		else
		{
			if (prev_position == null)
			{
				prev_position = transform.position;
			}

			if (currentProtection > 0) //Protegido
			{
				LossProtection(2*Time.deltaTime);
				if(currentProtection < 0) currentProtection = 0;
			}
			else //Desprotegido
			{
				TakeDamage(Time.deltaTime + Mathf.Abs((prev_position.x - transform.position.x) + (prev_position.y - transform.position.y) + (prev_position.y - transform.position.y)));
			}
			prev_position = transform.position;



			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				//if(mascarillaPapel.unit > 0 && currentHealth > 0) {
					
					if(mascarillaPapel.lossMascarilla()){
						currentProtection = mascarillaPapel.getProtection();
						
					}
					
				//}
			} else if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				//if(mascarillaPlastico.unit > 0 && currentHealth > 0) {
					
					if(mascarillaPlastico.lossMascarilla()){
						currentProtection = mascarillaPlastico.getProtection();
						
					}
					
				//}
			} else if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				//if(mascarillaFibra.unit > 0 && currentHealth > 0) {
					
					if(mascarillaFibra.lossMascarilla()){
						currentProtection = mascarillaFibra.getProtection();
					}
				
				//}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				//if(gel.unidades > 0 && currentHealth > 0) {
					if(gel.quitarUnidades()) {

						currentProtection += 15f;
						if(currentProtection > maxProtection) currentProtection = maxProtection;
					}
				//}
			}
			/*else if(Input.GetKeyDown(KeyCode.J)){
				money.addMoney(15);
			}*/

			if (Input.GetKeyDown(KeyCode.E))
			{
				if(checkDistance(pharmacyList)) toggleShop = !toggleShop;
			}
			if (toggleShop){
				if(Time.timeScale == 1.0) {
					Time.timeScale = 0.0f;
					
					camera.GetComponent<CameraController>().enabled = false;
					shop.Awake();
				}
			}
			else if(!toggleShop){
				if(Time.timeScale == 0.0){
					Time.timeScale = 1.0f;
					
					camera.GetComponent<CameraController>().enabled = true;
					shop.SleepShop();
				}
			}

			
		}
		money.updateMoney();
	}
	void TakeDamage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
	public void LossProtection(float damage)
	{
		currentProtection -= damage;

		procBar.SetProtection(currentProtection);
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
	bool checkDistance(GameObject[] lists)
    {
		int distance;
		for (int iter = 0; iter < pharmacyList.Length; iter++)
		{
			distance = (int)Vector3.Distance(pharmacyList[iter].transform.position, transform.position);
			if (distance <= 1) return true;
		}
		return false;

	}

	void OnGUI()
    {
		int windowWidth = 200;
		int windowHeight = 200;
		int x = (Screen.width - windowWidth) / 2;
		int y = (Screen.height - windowWidth) / 2;
		currentStyle = new GUIStyle(GUI.skin.box);
		currentStyle.normal.background = MakeTex(1, 1, Color.black);
		if (checkDistance(pharmacyList) && !toggleShop)
		{
			GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Pulsa E para entrar", currentStyle);
		}

	}
}
