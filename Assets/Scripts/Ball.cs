using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;

    private Vector2 paddleToBallVector;

    private void Start() => paddleToBallVector = transform.position - paddle.transform.position;

    private void Update() => transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + paddleToBallVector;
}
