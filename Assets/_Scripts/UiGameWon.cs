using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameWon : MonoBehaviour{
    GameManager gm;
    
    private void OnEnable(){
      gm = GameManager.GetInstance();
    }
    
    public void Restart(){
        gm.ChangeState(GameManager.GameState.GAME);
    } 

    public void Menu(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
