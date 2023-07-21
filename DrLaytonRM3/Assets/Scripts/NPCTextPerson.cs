using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable {
    
    public string message;
    public string message2;
    public string message3;
    public string message4;
    public string message5;

    private float cooldown = 4.0f;
    private float lastShout;

    protected override void Start() {
        base.Start();
        lastShout = -cooldown;
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if(Time.time - lastShout > cooldown)  {
            lastShout = Time.time;
            GameManager.instance.showText(message, 25, Color.white, transform.position + new Vector3(0, 0.50f, 0), Vector3.zero, cooldown);
            GameManager.instance.showText(message2, 25, Color.white, transform.position + new Vector3(0, 0.40f, 0), Vector3.zero, cooldown);
            GameManager.instance.showText(message3, 25, Color.white, transform.position + new Vector3(0, 0.30f, 0), Vector3.zero, cooldown);
            GameManager.instance.showText(message4, 25, Color.white, transform.position + new Vector3(0, 0.20f, 0), Vector3.zero, cooldown);
            GameManager.instance.showText(message5, 25, Color.white, transform.position + new Vector3(0, 0.10f, 0), Vector3.zero, cooldown);

        }
    }
}
