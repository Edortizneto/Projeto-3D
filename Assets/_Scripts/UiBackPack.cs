using UnityEngine;
using UnityEngine.UI;

public class UiBackPack : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }
    
    void Update(){
        textComp.text = $"Back Pack: {gm.backpack} / 3";
    }
}