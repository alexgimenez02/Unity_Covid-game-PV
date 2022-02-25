using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascarilla : MonoBehaviour
{
    public int maskType; //1 -> papel, 2 -> plastico, 3 -> fibra
    private float[] protection = {100f / 4f, 100f / 2f, 80f};
    private int[] prices = {10,50,100};
    public TextUnit txt;
    public int unit;
    public Money money;

    public float getUnit(){
        return unit;
    }

    public float getProtection(){
        return protection[maskType - 1];
    }

    public bool lossMascarilla(){
        
        if(unit > 0){
            txt.modifyText(--unit);
            return true;
        }
        return false;

    }
    public void addMascarilla(){
        if(money.checkMoney(prices[maskType - 1]))
            txt.modifyText(++unit);
        
    }

    public void numMasks(){
        txt.modifyText(unit);
        
    }
}
