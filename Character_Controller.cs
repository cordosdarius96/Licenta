using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{

    Rigidbody2D PlayerRb;
    BoxCollider2D boxCollider;
    [SerializeField]
    LayerMask GroundLayer;
    bool Jumped = false;
    [SerializeField]
    float JumpForce;
    int JumpCount = 0;
    bool MovingRight = false;
    bool MovingLeft = false;
    [SerializeField]
    float MoveSpeed;
    SpriteRenderer spriteRenderer;
    Animator animator;
   

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount > 0)
        {
            Jumped = true;
            JumpCount -= 1;
            animator.SetTrigger("Jump");
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            MovingRight = true;
            animator.SetBool("Run", true);
            spriteRenderer.flipX = false;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            MovingLeft = true;
            animator.SetBool("Run", true);
            spriteRenderer.flipX = true;
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("Run", false);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        if (Jumped)
        {
            PlayerRb.velocity = Vector2.up * JumpForce;
            Jumped = false;
        }
        if (Isgrounded())
        {
            JumpCount = 1;
        }
        if (MovingRight)
        {
            PlayerRb.transform.position += Vector3.right * MoveSpeed * Time.fixedDeltaTime;
            MovingRight = false;
        }
        if (MovingLeft)
        {
            PlayerRb.transform.position += Vector3.left * MoveSpeed * Time.fixedDeltaTime;
            MovingLeft = false;
        }
    }

    private bool Isgrounded()
    {
        RaycastHit2D Hitinfo = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f , GroundLayer);
        return Hitinfo.collider != null;
    }

    public void Death()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        Destroy(gameObject, 1f);
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(1);
    }


}