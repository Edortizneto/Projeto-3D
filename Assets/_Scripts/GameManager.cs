using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public enum GameState { MENU, GAME, PAUSE, GAMELOST, GAMEWON };
    public GameState gameState { get; private set; }
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate; 
    private static GameManager _instance;

    public static GameManager GetInstance(){
       if(_instance == null){
           _instance = new GameManager();
       }
       return _instance;
    }

    private GameManager(){
       gameState = GameState.MENU;
       FreezeGame(gameState);
    }

    public void ChangeState(GameState nextState){
        gameState = nextState;
        FreezeGame(nextState);
        changeStateDelegate();
    }

    public void FreezeGame(GameState currentState){
        if(currentState != GameState.GAME){
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }  
}
