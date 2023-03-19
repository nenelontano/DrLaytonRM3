using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
  //Text fields
  public Text levelText,hitpointText,pesosText,upgradeCostText,xpText;

  //logic
  private int currentCharacterSelection=0;
  public Image characterSelectionSprite;
  public Image weaponSprite;
  public RectTransform xpBar;

  //Character Selection
  public void OnArrowClick(bool right){
    if(right){
        currentCharacterSelection++;

        //if we went too far away
        if(currentCharacterSelection==GameManager.instance.playerSprites.Count)
            currentCharacterSelection=0;

        OnSelectionChanged();    
    }
    else{
         currentCharacterSelection--;

        //if we went too far away
        if(currentCharacterSelection<0)
            currentCharacterSelection=GameManager.instance.playerSprites.Count-1;

        OnSelectionChanged();   

    }
  } 

  public void OnSelectionChanged(){
    characterSelectionSprite.sprite=GameManager.instance.playerSprites[currentCharacterSelection];
  }

  //weapon upgrade
  public void OnUpgradeClick(){

  }

  //Update the character information
  public void UpdateMenu(){
    //Weapon
    weaponSprite.sprite=GameManager.instance.weaponSprites[0];
    upgradeCostText.text="NOT IMPLEMENTED";

    //Meta
    levelText.text="NOT IMPLEMENTED";
    hitpointText.text=GameManager.instance.player.hitpoint.ToString();
    pesosText.text=GameManager.instance.pesos.ToString();

    //xp Bar
    xpText.text="NOT IMPLEMENTED";
    xpBar.localScale=new Vector3(0.5f,0,0);
    }

  







}
