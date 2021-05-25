using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    private int life;
    Animator animator;
    public AudioClip die; 

    // Start is called before the first frame update
    void Start()
    {
        life = 10;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Take damage");   
        life -= damage;
        Debug.Log(life);
        if (life <=0)
            Die();
    }
    
    private void Die()
    {
        AudioManager.PlaySFX(die);

        animator.SetTrigger("Death");
    }
    

}
