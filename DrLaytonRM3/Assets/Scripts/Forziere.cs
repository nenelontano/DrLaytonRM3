using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forziere : Collectable

{
    public Sprite forziereVuoto;
    public int contoMonete = 5;

    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = forziereVuoto;
            Debug.Log("Guadagnato" + contoMonete + "monete!");
        }
    }

}