using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;
    
    private void Awake() {
        
        if(GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }
        
        instance=this;
        SceneManager.sceneLoaded += LoadState;
        
        //assicura che quando cambi scena il game manager resta:
        DontDestroyOnLoad(gameObject);
    }

    //risorse per il gioco
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //referenze
    public player player;

 //public  weapon
    public FloatingTextManager FloatingTextManager;

    //logica
    public int pesos;
    public int experience;

    //floating text
    public void showText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        FloatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }

    //stato salvato
    public void SaveState() {

        Debug.Log("SaveState");

        /*string s = "";

        s += "0"+ "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);*/
    }

    //stato caricato
    public void LoadState(Scene s, LoadSceneMode mode) {

       /* if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);*/

        Debug.Log("LoadState");
    }

}
 