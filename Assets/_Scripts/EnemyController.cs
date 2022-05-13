using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gm;
    Vector3 startPos = new Vector3( -27, 0, 41);
    Vector3 attackPos = new Vector3( -27, 50, 41);
    Vector3 attackFwd = new Vector3( -27, 50, 41);
    GameObject player;
    float countdown;
    bool isSpanwed = false;
    void Start()
    {
        gm = GameManager.GetInstance();
        countdown = 5;
        player = GameObject.Find("Player");
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update(){
        Debug.Log(countdown);
        if (countdown <= 0) {
            countdown = 5;
            attackPos = player.transform.position;
            attackFwd = player.transform.forward;
            attackPos.y += 10.0f;
            transform.position = attackPos + attackFwd*10.0f;
            isSpanwed = true;
            
        }
        countdown -= Time.deltaTime;
        // else {
        //     isSpanwed = false;
            
        //     transform.position = startPos;
        // }
    }
}
