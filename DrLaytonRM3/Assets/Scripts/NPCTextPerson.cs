using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable {
    
    public string message;

    private float cooldown = 4.0f;
    private float lastShout;

    protected override void Start() {
        base.Start();
        lastShout = -cooldown;
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if(Time.time - lastShout > cooldown)  {
            lastShout = Time.time;
            GameManager.instance.showText(message, 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
}
