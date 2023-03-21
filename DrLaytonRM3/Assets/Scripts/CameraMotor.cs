using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;     //è il personaggio(per ora)
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    public void Start(){
        lookAt=GameObject.Find("Player").transform;
    }

    private void LateUpdate() {
        Vector3 delta = Vector3.zero;

        //questo è per controllare se siamo dentro i limiti dell'asse x
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX) {
            if(transform.position.x < lookAt.position.x) {
                delta.x = deltaX - boundX;
            }
            else {
                delta.x = deltaX + boundX;
            }

        }

         //questo è per controllare se siamo dentro i limiti dell'asse y
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY) {
            if(transform.position.y < lookAt.position.y) {
                delta.y = deltaY - boundY;
            }
            else {
                delta.y = deltaY + boundY;
            }

        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
