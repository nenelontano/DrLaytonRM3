using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portale : Collidable
{
    [SerializeField] private AudioSource portaleSoundEffect;
    public string[] sceneNames;

    /*protected override void OnCollide(Collider2D coll)
    {
        if(coll.name=="Player")
        {
            //teletrasportalo
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }*/

private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Fighter"))
        {
            portaleSoundEffect.Play();
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }
    }


}
