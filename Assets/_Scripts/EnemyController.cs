using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    private int life;
    Animator animator;
    public AudioClip die; 
    private bool isDead = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        life = 6;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
            agent.SetDestination(player.transform.position);
        
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Take damage");   
        life -= damage;
        // Debug.Log(life);
        if (life <=0 && !isDead)
            Die();
    }
    
    private void Die()
    {
        AudioManager.PlaySFX(die);
        animator.SetTrigger("Death");
        isDead = true;
    }
}
