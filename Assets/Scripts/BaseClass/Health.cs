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
            // Ölüm animasyonu
            anim.SetTrigger("hit");
            // Animasyon sonrasý yok etme
            anim.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void destroyGameObject()
    {
        Destroy(gameObject);
    }


}
