using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;
    
    private void Awake() {
        instance=this;
    }

    //risorse per il gioco
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //referenze
    public player player;

    //logica
    public int pesos;
    public int experience;

    //stato salvato
    public void SaveState() {
        Debug.Log("SaveState");
    }

    //stato caricato
    public void LoadState() {
        Debug.Log("LoadState");
    }

}
 