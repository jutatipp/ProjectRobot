using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public Text scoreText;
    public HealthBar healthBar;
    public SceneManage scene;
    
    AudioManager audioManager;
    private float dirX, moveSpeed;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Health.totalHealth = 1f;
        
    }

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        scoreText.text = "Score :" + Scoring.totalScore;
        moveSpeed = speed; // กำหนดค่า moveSpeed
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            transform.localScale = new Vector2(3.267038f, 3.267038f);
        }
        else if (direction < 0f)
        {
            transform.localScale = new Vector2(-3.267038f, 3.267038f);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            audioManager.PlaySFX(audioManager.jumpSound);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        CheckDeath();
    }

    private void FixedUpdate()
    {
        player.velocity = new Vector2(direction * speed, player.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            audioManager.PlaySFX(audioManager.fallSound);
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            audioManager.PlaySFX(audioManager.Check);
        }
        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Crystals")
        {
            Scoring.totalScore += 1;
            scoreText.text = "Score :" + Scoring.totalScore;
            collision.gameObject.SetActive(false);
            audioManager.PlaySFX(audioManager.coinCollect);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spikes")
        {
            healthBar.Damage(0.0002f);
            audioManager.PlaySFX(audioManager.Spikes_);
        }
    }

    private void CheckDeath()
    {
        if (Health.totalHealth <= 0)
        {
            scene.DeathScene();
        }
    }
    
}

