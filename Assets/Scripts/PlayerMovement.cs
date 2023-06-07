using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] public float jumpForce = 8f;
    [SerializeField] private float raycastLength = 5f;
    [SerializeField] private LayerMask jumpableGround;

    private float horizontal;


    private Rigidbody2D rb;    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private PlayerHealth playerHealth;
    

   
    private enum AnimationState { IDLE, RUNNING, JUMPING, FALLING}
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        playerMovement(horizontal);
        updateAnimationState(horizontal);



    }



    private void playerMovement(float horizontal)
    {

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void updateAnimationState(float horizontal)
    {

        AnimationState state;

        if(Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {

                animator.SetTrigger("isAttack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);   // verdiðimiz noktada bir circle oluþturur. ve bu circle'a çarpanlarý bildirir.
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyHealth>().takeDamage(50);
                }


                nextAttackTime = Time.time + 1f / attackRate; 
            }
        }

        if (horizontal > 0f)
        {
            state = AnimationState.RUNNING;
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = AnimationState.RUNNING;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = AnimationState.IDLE;
        }

        if (rb.velocity.y > .1f)
        { 
            state = AnimationState.JUMPING;
        }
        else if (rb.velocity.y < -.1f) 
        {
            state = AnimationState.FALLING;
        }
        animator.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);   // bu metod true ya da false return eder.
    }



    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
