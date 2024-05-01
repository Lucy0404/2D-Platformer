using Assets.Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpForce = 500f;
    [SerializeField] public Animator animator;
    [SerializeField] public GameObject victoryUI;
    [SerializeField] public GameObject deathUI;
    [SerializeField] public KeyLogic key;

    public float moveInput;
    public bool grounded = false;
    public Tilemap tilemap;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GroundChecker groundChecker;
    public AudioManager audioManager;

    public float deathPositionY = -50f; // Позиция Y, после которой игрок умирает
    

    public bool isGrounded => groundChecker.IsGrounded;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        groundChecker = GetComponentInChildren<GroundChecker>();

        tilemap = FindObjectOfType<Tilemap>();
        animator = sr.GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
        key = GetComponent<KeyLogic>();
    }

    public void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0.01f)
        {
            sr.flipX = false;
        }
        else if (moveInput < -0.01f)
        {
            sr.flipX = true;
        }

        if (isGrounded)
        {
            bool isMoving = Mathf.Abs(moveInput) > 0.1f;
                animator.SetBool("isMoving", isMoving);
        }
       
            animator.SetBool("isJumping", !isGrounded);             
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        if (transform.position.y < deathPositionY)
        {
            deathUI.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            if (key.collectedKeys == key.totalKeys)
            {
                GetComponent<PlayerMovement>().enabled = false;
                audioManager.PauseMusic();
                key.victoryUI.SetActive(true);
            }
            else
            {
                key.ShowIncompleteText();
            }
        }
    }
}
