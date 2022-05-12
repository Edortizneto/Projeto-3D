using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Item") {
            gm.backpack++;
            Destroy(other.gameObject);
        }
        //Debug.Log(other.gameObject.name);
    }
}
