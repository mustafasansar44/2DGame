using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private Animator anim;



    private PlayerHealth playerHealth;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        //Attack only when player in sight?
        if (playerInSight())
        {
            if (cooldownTimer >= attackCooldown){
                cooldownTimer = 0;
                // melee attack
                Debug.Log("ENEMY ATTACK");
                anim.SetTrigger("isAttack");
            }
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }






    bool playerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.collider.GetComponent<PlayerHealth>();

        return hit.collider != null;
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    void damagePlayer()
    {
        // player halen alan içindeyse
        if (playerInSight())
        {
            // DAMAGE PLAYER HEALT
            playerHealth.takeDamage(damage);

        }
    }

}




    
