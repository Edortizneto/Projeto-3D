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
    }
}