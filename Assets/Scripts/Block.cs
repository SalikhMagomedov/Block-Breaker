using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVfx;
    [SerializeField] private int maxHits;

    private Level level;
    private GameSession gameStatus;
    private int timesHit;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        if (CompareTag("Breakable"))
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                var sparkles = Instantiate(blockSparklesVfx, transform.position, transform.rotation);
                Destroy(sparkles, 1f);

                level.BlockDestroyed();
                gameStatus.AddToScore();

                Destroy(gameObject);
            }
        }
    }
}
