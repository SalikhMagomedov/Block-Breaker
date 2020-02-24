using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVfx;

    private Level level;
    private GameSession gameStatus;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void Start() => level.CountBreakableBlocks();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        var sparkles = Instantiate(blockSparklesVfx, transform.position, transform.rotation);
        Destroy(sparkles, 1f);

        Destroy(gameObject);
    }
}
