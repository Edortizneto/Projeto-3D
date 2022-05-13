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
    public AudioClip SpawnAudio;
    AudioManager am;


    float countdown;
    //bool isSpanwed = false;
    void Start(){
        am = AudioManager.GetInstance();
        gm = GameManager.GetInstance();
        countdown = 10;
        player = GameObject.Find("Player");
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update(){
        if (gm.gameState != GameManager.GameState.GAME && gm.gameState != GameManager.GameState.PAUSE) transform.position = startPos;
        if (countdown <= 0) {
            AudioManager.PlaySFX(SpawnAudio);
            countdown = 10 - gm.collected;
            attackPos = player.transform.position;
            attackFwd = player.transform.forward;
            attackPos.y += 12.0f;
            transform.position = attackPos + attackFwd*(10.0f - gm.backpack);
            Vector3 localPos = transform.InverseTransformDirection(player.transform.position-transform.position);
            localPos.y = 0;
            Vector3 lookPos = transform.position + transform.TransformDirection(localPos);
            transform.LookAt(lookPos);
            //isSpanwed = true;
        }
        countdown -= Time.deltaTime;
    }
}
