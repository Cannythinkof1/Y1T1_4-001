using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[,] coins;
    public int gridSize = 5;
 //   public int numberToSpawn = 10;
 //   public float distanceCoin = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
   //     for (var i = 0; i < numberToSpawn; i++)
   //     {
   //         Instantiate(coin, new Vector3(i * distanceCoin, 0, 0), Quaternion.Euler(0, 0, -90));
   //     }
        coins = new GameObject[gridSize, gridSize];
        
        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; i < gridSize; j++)
            {
                Debug.Log("Row" + i + ",Column" + j + ":" + coins[i, j]);
                Vector3 positionOffset = new Vector3(i, 0, j);
                coins[i,j] = Instantiate(coinPrefab, positionOffset, Quaternion.identity, this.transform);
            }
        }
    }
}
