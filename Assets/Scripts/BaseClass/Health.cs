using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    [SerializeField] private Animator anim;
    public virtual void takeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            // �l�m animasyonu
            anim.SetTrigger("hit");
            // Animasyon sonras� yok etme
            anim.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void destroyGameObject()
    {
        Destroy(gameObject);
    }


}
