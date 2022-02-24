using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUnit : MonoBehaviour
{
    public Text unitText;

    public void modifyText(int u){
        unitText.text = u + " u";
    }
    public string getText(){
        return unitText.text;
    }
    
}
