using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] spawnSpots;
    public GameObject[] Items;
    private int randomSpawnSpot;

    int Rand;
    int[] LastRand;
    int Max = 3;
 
    void Start ()
    {
        Generator();
    }

    void Generator()
    {
        LastRand = new int[Max];
 
        for (int i = 0; i < Max; i++)
        {
            Rand = Random.Range(0, 5);
 
            for (int j = 0; j < i; j++)
            {
                while (Rand == LastRand[j])
                {
                    Rand = Random.Range(0, 5);
                }
            }
 
            LastRand[i] = Rand;
            Instantiate(Items[i], spawnSpots[Rand].transform.position, Quaternion.identity);
        }
    }

    void Update()
    {

    }
}
