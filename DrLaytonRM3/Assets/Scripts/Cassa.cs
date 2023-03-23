using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassa : Fighter
{
    protected override void Death(){
        Destroy(gameObject);
    }
 
}
