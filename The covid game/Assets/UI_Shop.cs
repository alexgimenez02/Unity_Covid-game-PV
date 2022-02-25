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

    public void Awake(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shop");
        shopItemTemplate.gameObject.SetActive(true);
    }
    public void SleepShop(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shop");
        shopItemTemplate.gameObject.SetActive(false);
    }
    public void buyMaskItem(Mascarilla mask){
		mask.addMascarilla();
	}
	public void buyGelItem(Gel g){
		g.addUnidades();
	}
}
