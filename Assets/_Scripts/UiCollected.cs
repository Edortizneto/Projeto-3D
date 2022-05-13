using UnityEngine;
using UnityEngine.UI;

public class UiCollected : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }
    
    void Update(){
        textComp.text = $"Collected: {gm.collected} / 3";
    }
}
