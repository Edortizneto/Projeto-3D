using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gm;
    Vector3 startPos = new Vector3( -27, 40, 41);
    Vector3 testPos = new Vector3( -27, 50, 41);
    GameObject player;
    bool isSpanwed = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        player = GameObject.Find("Player");
        //Debug.Log($"GM Prog = {gm.progression}");
        //gameObject.SetActive(false);
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{gm.progression}");
        if (gm.progression > 1 && gm.progression % 2 == 0) {
            //Debug.Log("Liguei");
            if (!isSpanwed){
                testPos = player.transform.position;
                testPos.y += 10.0f;
                transform.position = testPos;
                isSpanwed = true;
            }
        }
        else {
            isSpanwed = false;
            //Debug.Log("Desliguei");
            //gameObject.SetActive(false);
             transform.position = startPos;
        }
    }
}
