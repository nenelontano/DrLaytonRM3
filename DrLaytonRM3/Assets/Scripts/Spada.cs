using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spada : Collidable
{
 //Damage struct
 public int damagePoint=1;
 public float pushForce=2.0f;

 //Upgrade
 public int weaponLevel=0;
 private SpriteRenderer SpriteRenderer;

 //Swing
 private float cooldown=0.5f;
 private float lastSwing;

 protected override void Start(){
    base.Start();
    SpriteRenderer=GetComponent<SpriteRenderer>();
 }

 protected override void UpDate(){
    base.UpDate();
    if(Input.GetKeyDown(KeyCode.Space)){
        if(Time.time-lastSwing>cooldown){
            lastSwing=Time.time;
            Swing();
        }
    }
 }

protected override void OnCollide(Collider2D coll){
    if(coll.tag=="Fighter"){
        if(coll.name=="Player")
            return;
    
        Debug.Log(coll.name);
    }
}

 private void Swing(){
    Debug.Log("Swing");
 }
}
