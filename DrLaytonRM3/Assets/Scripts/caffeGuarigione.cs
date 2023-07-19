using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caffeGuarigione : Collidable {
    
    [SerializeField] private AudioSource vitaSoundEffect;
    public int healingAmount = 1;

    private float healCooldown = 1.0f;
    private float lastHeal;


    private void OnTriggerEnter2D(Collider2D coll) {
        vitaSoundEffect.Play();
        if(coll.name != "Player")
            return;

        if(Time.time - lastHeal > healCooldown) {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healingAmount);
        }
    }


    /*protected override void OnCollide(Collider2D coll) {

        if(coll.name != "Player")
            return;

        if(Time.time - lastHeal > healCooldown) {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healingAmount);
        }
    }*/
}
