using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collidable : MonoBehaviour {
    
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];     //array in cui memorizzo le collisioni che incontro

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpDate() {
        //collision work
        boxCollider.OverlapCollider(filter, hits);
        for(int i=0; i<hits.Length; i++) {
            if(hits[i]==null)
                continue;
            
            OnCollide(hits[i]);

            //puliamo l'array
            hits[i]=null;
        }
    }

    protected virtual void OnCollide(Collider2D coll) {
        Debug.Log(coll.name);
    }

}
