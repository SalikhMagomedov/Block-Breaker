using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;

    private GameSession gameSession;
    private Ball ball;

    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update() => transform.position = new Vector2(
        Mathf.Clamp(GetXPos(), minX, maxX),
        transform.position.y);

    private float GetXPos() => gameSession.IsAutoPlayEnabled 
        ? ball.transform.position.x 
        : Input.mousePosition.x / Screen.width * screenWidthInUnits;
}
