using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float gameSpeed = 1f;

    // Update is called once per frame
    void Update() => Time.timeScale = gameSpeed;
}
