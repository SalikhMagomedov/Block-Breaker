using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private Vector2 push = new Vector2(2f, 15f);

    private Vector2 paddleToBallVector;
    private Rigidbody2D rb;
    private bool hasStarted = false;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start() => paddleToBallVector = transform.position - paddle.transform.position;

    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle() => transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + paddleToBallVector;
    
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = push;
            hasStarted = true;
        }
    }
}
