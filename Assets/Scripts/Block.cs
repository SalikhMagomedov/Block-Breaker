using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVfx;
    [SerializeField] private Sprite[] hitSprites;

    private Level level;
    private GameSession gameStatus;
    private int timesHit;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            var maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                var sparkles = Instantiate(blockSparklesVfx, transform.position, transform.rotation);
                Destroy(sparkles, 1f);

                level.BlockDestroyed();
                gameStatus.AddToScore();

                Destroy(gameObject);
            }
            else
            {
                var spriteIndex = timesHit - 1;
                if (timesHit <= hitSprites.Length && hitSprites[spriteIndex] != null)
                {
                    spriteRenderer.sprite = hitSprites[spriteIndex];
                }
                else
                {
                    Debug.LogError("Block sprite is missing from array " + gameObject.name);
                }
            }
        }
    }
}
