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


    private GameObject go1, go2, go3, go4;
    private int windowWidth, windowHeight, x, y;
    private GUIStyle currentStyle;
    private Vector3 prev_position;
    private Transform transform;
    private bool toggleShop, deletedStore;
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
        go1 = GameObject.Find("/Canvas/Mascarilla Papel"); ;
        go2 = GameObject.Find("/Canvas/Mascarilla Plastico"); ;
        go3 = GameObject.Find("/Canvas/Mascarilla Fibra"); ;
        go4 = GameObject.Find("/Canvas/Gel");
        
        deletedStore = false;

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
                LossProtection(2 * Time.deltaTime);
                if (currentProtection < 0) currentProtection = 0;
            }
            else //Desprotegido
            {
                TakeDamage(Time.deltaTime + Mathf.Abs((prev_position.x - transform.position.x) + (prev_position.y - transform.position.y) + (prev_position.y - transform.position.y)));
            }
            prev_position = transform.position;


            if (!toggleShop)
            {
                if (Time.timeScale == 0.0)
                {
                    Time.timeScale = 1.0f;

                    camera.GetComponent<CameraController>().enabled = true;
                    go1.gameObject.SetActive(true);
                    go2.gameObject.SetActive(true);
                    go3.gameObject.SetActive(true);
                    go4.gameObject.SetActive(true);
                    shop.SleepShop();
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {


                    if (mascarillaPapel.lossMascarilla())
                    {
                        currentProtection = mascarillaPapel.getProtection();

                    }


                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {


                    if (mascarillaPlastico.lossMascarilla())
                    {
                        currentProtection = mascarillaPlastico.getProtection();

                    }


                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {


                    if (mascarillaFibra.lossMascarilla())
                    {
                        currentProtection = mascarillaFibra.getProtection();
                    }


                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {

                    if (gel.quitarUnidades())
                    {

                        currentProtection += 15f;
                        if (currentProtection > maxProtection) currentProtection = maxProtection;
                    }

                }
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                if (deletedStore)
                {

                    toggleShop = !toggleShop;
                    deletedStore = !deletedStore;
                }
                else if (checkDistance(pharmacyList))
                {
                    toggleShop = !toggleShop;
                    int inx = checkDistanceIndex(pharmacyList);
                    if (currentProtection <= 0) {
                        pharmacyList[inx].gameObject.SetActive(false);
                        
                        deletedStore = !deletedStore;
                    }
                }
                
            }
            if (toggleShop)
            {
                if (Time.timeScale == 1.0)
                {
                    Time.timeScale = 0.0f;

                    camera.GetComponent<CameraController>().enabled = false;
                    go1.gameObject.SetActive(false);
                    go2.gameObject.SetActive(false);
                    go3.gameObject.SetActive(false);
                    go4.gameObject.SetActive(false);
                    shop.Awake();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (money.checkMoney(10))
                    {
                        shop.buyMaskItem(mascarillaPapel);
                        money.substractMoney(10);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if (money.checkMoney(50))
                    {
                        shop.buyMaskItem(mascarillaPlastico);
                        money.substractMoney(50);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    if (money.checkMoney(100))
                    {
                        shop.buyMaskItem(mascarillaFibra);
                        money.substractMoney(100);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if (money.checkMoney(5))
                    {
                        shop.buyGelItem(gel);
                        money.substractMoney(5);
                    }
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
    private bool checkDistance(GameObject[] lists)
    {
        int distance;
        for (int iter = 0; iter < lists.Length; iter++)
        {
            if (lists[iter].gameObject.activeSelf) 
            { 
                distance = (int)Vector3.Distance(lists[iter].transform.position, transform.position);
                if (distance <= 1) return true;
            }
        }
        return false;

    }
    private int checkDistanceIndex(GameObject[] lists)
    {
        int distance;
        for(int iter = 0; iter < lists.Length; iter++)
        {
            if (lists[iter].gameObject.activeSelf)
            {
                distance = (int)Vector3.Distance(lists[iter].transform.position, transform.position);
                if (distance <= 1) return iter;
            }
        }
        return -1;
    }

    void OnGUI() 
    {
        int windowWidth = 200;
        int windowHeight = 200;
        int x = (Screen.width - windowWidth) / 2;
        int y = (Screen.height - windowWidth) / 2;
        currentStyle = new GUIStyle(GUI.skin.box);
        currentStyle.normal.background = MakeTex(1, 1, new Color(0, 0, 0, 0));
        currentStyle.normal.textColor = Color.black;
        if (checkDistance(pharmacyList) && !toggleShop)
        {
            GUI.Label(new Rect(x, y - 80, windowWidth, windowHeight), "Pulsa E para entrar", currentStyle);
        }

    }
}
