using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGamePause : MonoBehaviour{

    GameManager gm;
    
    private void OnEnable(){
      gm = GameManager.GetInstance();
    }
    
    public void ResumeGame(){
        gm.ChangeState(GameManager.GameState.GAME);
    } 

    public void QuitGame(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
