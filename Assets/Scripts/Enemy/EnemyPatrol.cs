using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;


    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft = true;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                
                moveDirection(-1);
            }
            else
            {
                // Change direction
                changeDirection();
            }
                
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                moveDirection(1);
            }
            else
            {
                // Change direction
                changeDirection();
            }

        }
    }

    private void changeDirection()
    {
        movingLeft = !movingLeft;
    }

    private void moveDirection(int direction)
    {
        anim.SetInteger("state", 1);
        // Enemy face direction
        enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

        // move that position
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }
}
 