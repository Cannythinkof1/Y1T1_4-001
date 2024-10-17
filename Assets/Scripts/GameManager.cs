using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //number of coins required for a win
    public int collectionTarget = 10;
    //initial value for number of coins collected
    private int collectedCoin = 0;

    //default value of pause state
    private bool isPaused = false;

    //counts the number of coins collected and outputs tally and win state to debug log
    public void AddCollectedCoin(int amount)
    {
        //adds coins to the tally
        collectedCoin += amount;

        //determines win
        if (collectedCoin >= collectionTarget)
        {
            Debug.Log("You Won!");
        }
        //keeps score
        else
        {
            Debug.Log("Coins Collected: " +  collectedCoin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    //pauses and unpauses the game
    void Pause()
    {
        //checks for player input
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if isPaused = true, unpauses the game
            if (isPaused)
            {
                Time.timeScale = 1.0f;
            }
            //if isPaused = false, pauses the game
            else
            {
                Time.timeScale = 0.0f;
            }

            //sets isPaused to false
            isPaused = !isPaused;
        }
    }
}
