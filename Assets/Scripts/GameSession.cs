using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private bool isAutoPlayEnabled;

    public bool IsAutoPlayEnabled { get => isAutoPlayEnabled; }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() => UpdateScoreText();

    // Update is called once per frame
    void Update() => Time.timeScale = gameSpeed;

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        UpdateScoreText();
    }

    public void ResetGame() => Destroy(gameObject);

    private void UpdateScoreText() => scoreText.text = currentScore.ToString();
}
