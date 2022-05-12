using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gm;
    Vector3 startPos = new Vector3( -27, 40, 41);
    Vector3 attackPos = new Vector3( -27, 50, 41);
    Vector3 attackFwd = new Vector3( -27, 50, 41);
    GameObject player;
    bool isSpanwed = false;
    void Start()
    {
        gm = GameManager.GetInstance();
        player = GameObject.Find("Player");
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update(){
        if (gm.progression > 1 && gm.progression % 2 == 0) {
            if (!isSpanwed){
                attackPos = player.transform.position;
                attackFwd = player.transform.forward;
                attackPos.y += 15.0f;
                transform.position = attackPos + attackFwd*15.0f;
                isSpanwed = true;
            }
        }
        else {
            isSpanwed = false;
            transform.position = startPos;
        }
    }
}
