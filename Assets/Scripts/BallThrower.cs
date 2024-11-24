using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    private ScoreManager scoreManager;
    public float throwForce = 10f;

    private Vector3 dragStart, dragEnd;
    private bool isDragging = false;

    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }
    void Update()
    {
        if (scoreManager.isGameActive == true)
        {
            // Start dragging to aim
            if (Input.GetMouseButtonDown(0))
            {
                dragStart = Input.mousePosition;
                isDragging = true;
            }

            // Release to throw
            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                dragEnd = Input.mousePosition;
                ThrowBall();
                isDragging = false;
            }

        }
        
    }

    void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Calculate direction and force based on the drag
        Vector3 dragVector = (dragEnd - dragStart);
        Vector3 throwDirection = new Vector3(dragVector.x, dragVector.y, 1);  // Forward toss
        rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
    }
}

