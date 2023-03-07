using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        
        if(GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        
    }

    //Risorse
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //riferimenti (l'ho commentato perche altrimenti da errore sperando che dopo venga aggiustato)
    public player player;

    //logic
    public int pesos;
    public int experience;

    //salva stato
    public void SaveState() {
        string s = "";

        s+= "0" + "|";
        s+= pesos.ToString() + "|";
        s+= experience.ToString() + "|";
        s+= "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode) {

        if(!PlayerPrefs.HasKey("SaveState"))
            return;


        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
    
        //change player skin
        pesos= int.Parse(data[1]);   //pesos sarà uguale al valore finale della stringa
        experience= int.Parse(data[2]);

        Debug.Log("LoadState");
    }

}
