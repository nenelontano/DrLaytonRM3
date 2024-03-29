using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forziere : MonoBehaviour
//public class Forziere : Collectable
{
    [SerializeField] private AudioSource collectionSoundEffect;
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
        if(other.CompareTag("Fighter"))
        {
            if(!collected)
            {
                collectionSoundEffect.Play();
                collected = true;
                GetComponent<SpriteRenderer>().sprite = forziereVuoto;
                GameManager.instance.pesos+=contoMonete;
                GameManager.instance.showText("+" +contoMonete+ "monete!",25,Color.yellow,transform.position,Vector3.up*50,3.0f);
            }
        }
    }

}