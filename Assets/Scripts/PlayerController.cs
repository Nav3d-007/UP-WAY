using Assets.Scripts;
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// THIS SCRIPT CAN BE SPLIT INTO TWO - 1) PLAYERCONTROLER AND 2)PLATYERMOVEMENT
/// </summary>
public class PlayerController : MonoBehaviour
{  

    public float jumpForce;
    public Sprite idleSprite;
    public Sprite fallSprite;
    public Sprite jumpSprite;
    public TextMeshProUGUI livesText;


    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private static int lives;
    private float moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupPlayer();
        UpdateLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); //1 or -1

        TogglePlayerHorizontalDir();
        UpdatePlayerSprites();
    }

    private void FixedUpdate()
    {
        float moveSpeed = 6f;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if(transform.position.y < ScreenBounds.Bottom && rb.linearVelocityY < 0) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            PlayerIsHurt();
        }
    }

    private void LateUpdate()
    {
        ClampPlayerX();
    }

    private void SetupPlayer()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = idleSprite;
        lives = 3;
    }

    private void UpdateLivesText()
    {
        livesText.text = $"Lives: {lives}";
    }
    


    private void UpdatePlayerSprites()
    {
        if (rb.linearVelocityY > 0.1f)// increading 
            sr.sprite = jumpSprite;
        else if (rb.linearVelocityY < -0.1f)//  descrinsing
            sr.sprite = fallSprite;
        else
            sr.sprite = idleSprite;
    }

    private void TogglePlayerHorizontalDir()
    {
        if (moveInput > 0) // 1 = towards right and -1 = towards left
            sr.flipX = false;
        else
            sr.flipX = true;
    }

    IEnumerator BlinkEffect()
    {
        for(int i =0; i < 5; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.1f);

            sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

   private void ClampPlayerX()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, ScreenBounds.Left, ScreenBounds.Right);
        transform.position = pos;
    }

    private void PlayerIsHurt()
    {
        lives--;
        UpdateLivesText();
        if (lives <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private void Die()
    {
        FindFirstObjectByType<GameOverManager>().GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerIsHurt();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.linearVelocityY = 0; //reset to avoid players acceleration to oblivion
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
