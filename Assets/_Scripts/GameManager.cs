using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{

    public enum GameState { MENU, GAME, PAUSE, GAMELOST, GAMEWON };
    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate; 
    private static GameManager _instance;
    private GameObject player;
    public int backpack;
    public int collected;
    public int progression;

    public static GameManager GetInstance(){
       if(_instance == null){
           _instance = new GameManager();
       }
       return _instance;
    }

    private GameManager(){
       gameState = GameState.MENU;
       lastState = GameState.MENU;
       player = GameObject.Find("Player");
       FreezeGame(gameState);
       progression = 0;
       backpack = 0;
       collected = 0;
    }

    public void ChangeState(GameState nextState){
        lastState = gameState;
        if ((gameState == GameState.GAMELOST || gameState == GameState.GAMEWON) && nextState == GameState.GAME) Reset();
        gameState = nextState;
        FreezeGame(nextState);
        changeStateDelegate();
    }

    public void Reset(){
        progression = 0;
        backpack = 0;
        collected = 0;
        player.transform.position = new Vector3(0, 10, 0);
    }

    public void FreezeGame(GameState currentState){
        if(currentState != GameState.GAME){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
