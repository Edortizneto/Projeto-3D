using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] spawnSpots;
    public GameObject[] Items;
    private GameObject item;
    private int randomSpawnSpot;
    private static ItemSpawner _instance;
    GameManager gm;

    int Rand;
    int[] LastRand;
    int Max = 3;
 
    void Start (){
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Generator;
        Generator();
    }


    public void Generator(){

        if (gm.lastState != GameManager.GameState.PAUSE && gm.gameState == GameManager.GameState.GAME){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Item");
            foreach(GameObject enemy in enemies) Destroy(enemy);
            LastRand = new int[Max];
            for (int i = 0; i < Max; i++){

                Rand = Random.Range(0, 4);
                while (LastRand.Contains(Rand)){
                    Rand = Random.Range(0, 4);
                }
                LastRand[i] = Rand;
                item = Instantiate(Items[i], spawnSpots[Rand].transform.position, Quaternion.identity);
                item.transform.Rotate(-90, 0, 0);
            }
        }
    }
}