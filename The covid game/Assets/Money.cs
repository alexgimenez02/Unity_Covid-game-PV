using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private int actualMoney;
    public Text text;

    public void readMoney(){
        actualMoney = int.Parse(text.text);
    }
    public void addMoney(int c){
        actualMoney += c;
    }
    public void substractMoney(int c){
        if(checkMoney(c)){
            actualMoney -= c;
            
        }
        
    }
    public bool checkMoney(int c){
        return c <= actualMoney;
    }
    public void updateMoney(){
        text.text = ""+actualMoney;
    }
}
