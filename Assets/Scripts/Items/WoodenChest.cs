using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenChest : MonoBehaviour
{

    private Animator anim;
    private bool playerInField = false;   // Player mi trigger alanýnda


    void Start()
    {
        anim = GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInField = true;
            anim.SetBool("playerInRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(playerInField)
        {
            anim.SetBool("playerInRange", false);
            playerInField = false;
        }
    }

    void Update()
    {
        
    }
}
