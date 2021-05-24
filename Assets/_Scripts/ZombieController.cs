using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    private int life;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        life = 30;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {   
        life -= damage;
        Debug.Log(life);
        if (life <=0)
            Die();
    }
    
    private void Die()
    {
        animator.SetTrigger("Death");
    }
    

}
