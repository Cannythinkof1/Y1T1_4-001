using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActions : MonoBehaviour
{
    //how fast coins rotate
    public float rotationSpeed = 50.0f;

    //how fast coins move up and down
    public float moveSpeed = 1.0f;
    //distance coins move up and down
    public float amplitude = 1.0f;

    //coin location
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        //define coin location
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveIt();
        ShakeIt();
    }

    //moves coin up and down
    void MoveIt()
    {
        float verticalMovement = Mathf.Sin(Time.time * moveSpeed) * amplitude;

        Vector3 newPosition = startPos + Vector3.up * verticalMovement;
        transform.position = newPosition;
    }

    //rotates the coin
    void ShakeIt()
    {
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }

    //destroys coin on contact with player and adds to the counter
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //adds coin to the overall count upon destruction
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.AddCollectedCoin(1);
            }

            //destroys coin object
            Destroy(gameObject);
        }
    }
}
