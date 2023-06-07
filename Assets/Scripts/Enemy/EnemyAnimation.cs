using UnityEngine;

public class EnemyAnimation: MonoBehaviour
{
    // state 0 ve 1 

    [SerializeField] private Animator anim;

    public void idle()
    {
        anim.SetInteger("state", 0);
    }
    public void walking()
    {
        anim.SetInteger("state", 1);
    }
    public void attacking()
    {
        anim.SetTrigger("attacking");
    }
    public void hit()
    {
        anim.SetTrigger("hit");
    }
    public void isDead()
    {
        anim.SetBool("isDead", true);
    }
}
