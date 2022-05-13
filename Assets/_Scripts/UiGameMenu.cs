using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameMenu : MonoBehaviour{
    GameManager gm;
    private void OnEnable(){
      gm = GameManager.GetInstance();
    }
    public void StartGame(){
        gm.ChangeState(GameManager.GameState.GAME);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
