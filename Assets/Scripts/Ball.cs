using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private Vector2 push = new Vector2(2f, 15f);
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = .2f;

    private Vector2 paddleToBallVector;
    private Rigidbody2D rb;
    private bool hasStarted = false;
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            audioSource.PlayOneShot(ballSounds[Random.Range(0, ballSounds.Length)]);
            rb.velocity += velocityTweak;
        }
    }
}
