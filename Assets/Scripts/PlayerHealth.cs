using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    [SerializeField] private float health = 100f;
    [SerializeField] private Animator anim;
    public virtual void takeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Can : " + health;
        if (health < 0)
        {
            healthText.text = "�LD�N!";
            // �l�m animasyonu
            anim.SetTrigger("hit");
            // Animasyon sonras� yok etme
            anim.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
            // restartScene yap!
        }
    }
    public void destroyGameObject()
    {
        Destroy(gameObject);
    }

    public void restartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
