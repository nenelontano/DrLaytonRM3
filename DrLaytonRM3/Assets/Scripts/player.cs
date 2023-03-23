using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Mover {
    
    private SpriteRenderer spriteRenderer;

    protected override void Start(){
        base.Start();
        spriteRenderer=GetComponent<SpriteRenderer>();

        DontDestroyOnLoad(gameObject);
    }

    protected override void ReceiveDamage(Damage dmg) {

        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitpointChange();
    }

     private void FixedUpdate() {
       
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x,y,0));
    }
    
    public void SwapSprite(int skinId){
        spriteRenderer.sprite=GameManager.instance.playerSprites[skinId];
    }

    public void OnLevelUp() {
    
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }
    
    public void SetLevel(int level)  {
    
        for(int i=0; i < level; i++) {
            OnLevelUp();
        }
    }

    public void Heal(int healingAmount) {

        if(hitpoint == maxHitpoint)
            return;

        hitpoint += healingAmount;
        if(hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
           
        GameManager.instance.showText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitpointChange();
    }
}
