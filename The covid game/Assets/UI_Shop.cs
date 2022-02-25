using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour, BuyBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    public Mascarilla mascarillaPapel;
    public Mascarilla mascarillaPlastico;
    public Mascarilla mascarillaFibra;
    public Gel gel;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public void Initialize(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }
    public void Awake(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
    }
    public void SleepShop(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }
    private void Update(){
        if(button1.isActiveAndEnabled){
            button1.onClick.AddListener(delegate {buyMaskItem(mascarillaFibra);});
        }
        else if(button2.isActiveAndEnabled){
            button2.onClick.AddListener(delegate {buyMaskItem(mascarillaPlastico);});
        }
        else if(button3.isActiveAndEnabled){
            button3.onClick.AddListener(delegate {buyMaskItem(mascarillaPapel);});
        }
        else if(button4.isActiveAndEnabled){
            button4.onClick.AddListener(delegate {buyGelItem(gel);});
        }
    }
    public void buyMaskItem(Mascarilla mask){
		mask.addMascarilla();
	}
	public void buyGelItem(Gel g){
		g.addUnidades();
	}
}
