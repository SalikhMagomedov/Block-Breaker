using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    [SerializeField] private int currentScore = 0;

    // Update is called once per frame
    void Update() => Time.timeScale = gameSpeed;

    public void AddToScore() => currentScore += pointsPerBlockDestroyed;
}
