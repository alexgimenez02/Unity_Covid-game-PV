using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gel : MonoBehaviour
{
    public int unidades;
    public int cantidad = 15;
    public Text geltxt;

    public void setUnidades(int u)
    {
        unidades = u;
    }
    public void quitarUnidades()
    {
        if (unidades > 0)
        {
            unidades--;
        }
        
    }
    public void devolverTexto()
    {
        geltxt.text = unidades + " u";
        
    }
}
