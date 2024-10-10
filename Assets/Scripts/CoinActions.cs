using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActions : MonoBehaviour
{
    public float rotationSpeed = 50.0f;

    public float moveSpeed = 1.0f;
    public float amplitude = 1.0f;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveIt();
        ShakeIt();
    }

    void MoveIt()
    {
        float verticalMovement = Mathf.Sin(Time.time * moveSpeed) * amplitude;

        Vector3 newPosition = startPos + Vector3.up * verticalMovement;
        transform.position = newPosition;
    }

    void ShakeIt()
    {
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.AddCollectedCoin(1);
            }

            Destroy(gameObject);
        }
    }
}
