using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassa : Fighter
{
    [SerializeField] private AudioSource cassaSoundEffect;
    protected override void Death(){
        cassaSoundEffect.Play();
        Destroy(gameObject);
    }
 
}
