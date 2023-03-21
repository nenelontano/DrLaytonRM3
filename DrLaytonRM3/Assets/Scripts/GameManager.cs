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
    public  Spada weapon;
    public FloatingTextManager FloatingTextManager;

    //logica
    public int pesos;
    public int experience;

    //floating text
    public void showText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        FloatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }

    //Upgrade Weapon
    public bool TryUpgradeWeapon(){
        //is the weapon max level?
        if(weaponPrices.Count<=weapon.weaponLevel)
            return false;

        if(pesos>=weaponPrices[weapon.weaponLevel]){
            pesos-=weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }    

        return false;
    }

    //Experience System
    public int GetCurrentLevel() {
    
        int r = 0;
        int add = 0;

        while (experience >= add) {       //in base al valore di experience vediamo a che livello stiamo
            add += xpTable[r];
            r++;
            
            if(r == xpTable.Count)      //stiamo al livello massimo
                return r;
        }

        return r;
    }

    public int GetXpToLevel(int level) {
    
        int r=0;
        int xp=0;

        while(r < level) {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }

    public void GrantXp(int xp) {

        int currLevel = GetCurrentLevel();
        experience += xp;
        if(currLevel < GetCurrentLevel())
            OnLevelUp();
    
    }

    public void OnLevelUp() {

        Debug.Log("Level up!");
        player.OnLevelUp();
    }

    //stato salvato
    public void SaveState() {

        //Debug.Log("SaveState");

        string s = "";

        s += "0"+ "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    //stato caricato
    public void LoadState(Scene s, LoadSceneMode mode) {

        Debug.Log("LoadState");
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        pesos = int.Parse(data[1]);

        //experience
        experience = int.Parse(data[2]);
        if(GetCurrentLevel() != 1)
            player.SetLevel(GetCurrentLevel());

        //change the weapon level
        weapon.SetWeaponLevel(int.Parse(data[3]));


        player.transform.position=GameObject.Find("SpawnPoint").transform.position;
    }

}
 