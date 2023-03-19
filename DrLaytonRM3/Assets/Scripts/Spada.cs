using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spada : Collidable {
 
    //Damage struct
    public int[] damagePoint={ 1,2,3,4,5,6,7};
    public float[] pushForce={ 2.0f, 2.2f, 2.5f , 3f, 3.2f ,3.6f, 4f};

    //Upgrade
    public int weaponLevel=0;
    public SpriteRenderer SpriteRenderer;

    //Swing
    private Animator anim;
    private float cooldown=0.5f;
    private float lastSwing;


    protected override void Start(){
        base.Start();
     //   SpriteRenderer=GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Fighter")){
            if(other.name=="Player")
                return;
        
            //Create a new Damage object, then we'll send it to the fighter we've hit
            Damage dmg=new Damage{
                damageAmount=damagePoint[weaponLevel],
                origin=transform.position,
                pushForce=pushForce[weaponLevel]
            };

            other.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing() {
       
        anim.SetTrigger("Swing");


    }

    public void UpgradeWeapon(){
        weaponLevel++;
        SpriteRenderer.sprite=GameManager.instance.weaponSprites[weaponLevel];

    }

    public void SetWeaponLevel(int level){
        weaponLevel=level;
        SpriteRenderer.sprite=GameManager.instance.weaponSprites[weaponLevel];

    }
}
