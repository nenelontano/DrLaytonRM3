using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        instance = this;
    }

    //Risorse
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //riferimenti (l'ho commentato perche altrimenti da errore sperando che dopo venga aggiustato)
    //public Player player;

    //logic
    public int pesos;
    public int experience;

    //salva stato
    public void SaveState() {
        Debug.Log("SaveState");
    }

    public void LoadState() {
        Debug.Log("LoadState");
    }

}
