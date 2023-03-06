using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forziere : MonoBehaviour
//public class Forziere : Collectable
{
    public Sprite forziereVuoto;
    public int contoMonete = 5;
    private bool collected;

    public void Awake()
    {
        collected = false;

    }
    

    // protected override void OnCollect()
    // {
    //     if(!collected)
    //     {
    //         collected = true;
    //         GetComponent<SpriteRenderer>().sprite = forziereVuoto;
    //         Debug.Log("Guadagnato" + contoMonete + "monete!");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(!collected)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = forziereVuoto;
                Debug.Log("Guadagnato" + contoMonete + "monete!");
            }
        }
    }

}