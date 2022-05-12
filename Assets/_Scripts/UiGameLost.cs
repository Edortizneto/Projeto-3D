using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGameLost : MonoBehaviour
{
    GameManager gm;
    
    private void OnEnable(){
      gm = GameManager.GetInstance();
    }
    
    public void TryAgain(){
        gm.ChangeState(GameManager.GameState.GAME);
    } 

    public void QuitGame(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
