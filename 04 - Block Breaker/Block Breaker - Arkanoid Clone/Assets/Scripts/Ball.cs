using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xForce = 2f;
    [SerializeField] float yForce = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    bool hasStarted = false;
    Vector2 paddleToBallVector;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        // Ball - Paddle 1 = Distância entre a bola e o paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(
            paddle1.transform.position.x,
            paddle1.transform.position.y
        );
        // A posição da bola segue a posição do paddle
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xForce, yForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor)
        );

       if (hasStarted)
        {
            if (collision.gameObject.name != "Paddle") // se o objeto de colisão não for o Paddle
            {
                AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
            }
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
