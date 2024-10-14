using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[,] coins;
    public int gridSize = 5;
    public float distanceCoin = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        coins = new GameObject[gridSize, gridSize];
        
        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Debug.Log("Row" + i + ",Column" + j + ":" + coins[i, j]);
                Vector3 positionOffset = new Vector3(i * distanceCoin, 0, j * distanceCoin);
                coins[i, j] = Instantiate(coinPrefab, positionOffset, Quaternion.Euler(0, 0, -90));
            }
        }
    }
}
