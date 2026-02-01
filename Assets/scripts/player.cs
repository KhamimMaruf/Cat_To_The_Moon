using UnityEngine;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 7f;

    [Header("Golden Fish Buff (Speed)")]
    public float buffMultiplier = 2f;
    public float buffDuration = 5f;

    [Header("Flying Fish Buff (Jump)")]
    public float jumpBuffMultiplier = 1f;
    public float jumpBuffDuration = 5f;

    [Header("UI")]
    public TMP_Text scoreText;

    [Header("Audio")]
    public AudioClip coinSound;
    private AudioSource audioSource;

    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;
    private bool isGrounded;

    public int score = 0;

    // Respawn
    private Vector2 checkpointPos;

    // Buff data
    private float originalSpeed;
    private float originalJumpForce;
    private bool isSpeedBuffActive = false;
    private bool isJumpBuffActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        checkpointPos = transform.position;

        originalSpeed = speed;
        originalJumpForce = jumpForce;

        UpdateScoreUI();
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
        CheckFall();
    }

    // ---------- MOVEMENT ----------
    void Move()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.D)) moveInput = 1f;
        else if (Input.GetKey(KeyCode.A)) moveInput = -1f;

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput > 0 && !facingRight) Flip();
        else if (moveInput < 0 && facingRight) Flip();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ---------- GROUND ----------
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    // ---------- TRIGGER ----------
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreUI();

            if (coinSound != null)
                audioSource.PlayOneShot(coinSound);
        }

        if (other.CompareTag("Respawn") || other.CompareTag("Checkpoint"))
        {
            checkpointPos = other.transform.position;
        }
    }

    // ---------- SPEED BUFF ----------
    public void ActivateSpeedBuff()
    {
        if (!isSpeedBuffActive)
            StartCoroutine(SpeedBuffCoroutine());
    }

    IEnumerator SpeedBuffCoroutine()
    {
        isSpeedBuffActive = true;
        speed *= buffMultiplier;

        yield return new WaitForSeconds(buffDuration);

        speed = originalSpeed;
        isSpeedBuffActive = false;
    }

    // ---------- JUMP BUFF ----------
    public void ActivateJumpBuff()
    {
        if (!isJumpBuffActive)
            StartCoroutine(JumpBuffCoroutine());
    }

    IEnumerator JumpBuffCoroutine()
    {
        isJumpBuffActive = true;
        jumpForce *= jumpBuffMultiplier;

        yield return new WaitForSeconds(jumpBuffDuration);

        jumpForce = originalJumpForce;
        isJumpBuffActive = false;
    }

    // ---------- UI ----------
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    // ---------- RESPAWN ----------
    void CheckFall()
    {
        if (transform.position.y < -8)
            Respawn();
    }

    void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = checkpointPos;
    }

    // ---------- ANIMATION ----------
    void UpdateAnimation()
    {
        anim.SetBool("isRunning", Mathf.Abs(rb.linearVelocity.x) > 0.1f);
        anim.SetBool("isJumping", !isGrounded);
    }
}
