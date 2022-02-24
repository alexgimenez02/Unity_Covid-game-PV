using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gel : MonoBehaviour
{
    public int unidades;
    public int cantidad = 15;
    public TextUnit txt;
    

    public void setUnidades(int u)
    {
        unidades = u;
        txt.modifyText(unidades);
    }
    public bool quitarUnidades()
    {
        if (unidades > 0)
        {
            unidades--;
            txt.modifyText(unidades);
            return true;
        }
        return false;
        
    }
    
}
