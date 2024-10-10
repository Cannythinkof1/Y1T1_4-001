using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int CollectedCoin = 0;
    private bool isPaused = false;

    public void AddCollectedCoin(int amount)
    {
        CollectedCoin += amount;

        if (CollectedCoin >= 2)
        {
            SceneManager.LoadScene("You Won!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }

            isPaused = !isPaused;
        }
    }
}
