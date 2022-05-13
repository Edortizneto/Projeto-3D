using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    GameManager gm;
    void Start(){
        gm = GameManager.GetInstance();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Item") {
            gm.backpack++;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Totem") {
            if (gm.backpack > 0){
                gm.collected += gm.backpack; 
                gm.backpack = 0;
            }
            if(gm.collected == 3){
                gm.ChangeState(GameManager.GameState.GAMEWON);
            }
        }
    }
    
}