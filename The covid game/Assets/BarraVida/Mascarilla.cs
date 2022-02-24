using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascarilla : MonoBehaviour
{
    public int maskType; //1 -> papel, 2 -> plastico, 3 -> fibra
    private float[] protection = {100f / 4f, 100f / 2f, 100f};
    public TextUnit txt;

    public float getProtection(){
        Debug.Log(protection);
        return protection[maskType - 1];
    }

    public bool lossMascarilla(){
        string actual_units = txt.getText();
        Debug.Log(actual_units);
        string[] split_text = actual_units.Split(" "[0]);
        int units = int.Parse(split_text[0]);
        if(units > 0)
            txt.modifyText(--units);
            return true;
        return false;

    }
    public void numMasks(){
        int unit = 2;
        txt.modifyText(unit);
        Debug.Log("Test numMasks en mascarilla: " + maskType);
    }
}
