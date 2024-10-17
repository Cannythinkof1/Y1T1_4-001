using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //object to be instantiated
    public GameObject coinPrefab;
    public GameObject[,] coins;

    //how large a grid to instantiate
    public int gridSize = 5;

    //distance between coins
    public float distanceCoin = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //what to instantiate and dimensions of the grid
        coins = new GameObject[gridSize, gridSize];
        
        //adds coins to the grid, up to gridsize
        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                //location of new coins modified by distanceCoin
                Vector3 positionOffset = new Vector3(i * distanceCoin, 0, j * distanceCoin);
                //instantiate coins using coin prefab rotated onto it's side
                coins[i, j] = Instantiate(coinPrefab, positionOffset, Quaternion.Euler(0, 0, -90));
            }
        }
    }
}
