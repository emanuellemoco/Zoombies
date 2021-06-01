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
    

    private bool isBarrier = false;
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
        if (!isDead && !isBarrier)
            agent.SetDestination(player.transform.position);
        
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Take damage");   
        life -= damage;

        if (life <=0 && !isDead)
            Die();
    }
    
    private void Die()
    {
        AudioManager.PlaySFX(die);
        animator.SetTrigger("Death");
        isDead = true;
        agent.ResetPath();
    }
    
    public void DestroyBarrier(){
        isBarrier = true;
        agent.ResetPath();
        animator.SetTrigger("Headbutting");
        StartCoroutine(headbuttFinished());

    }
    IEnumerator headbuttFinished() {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        isBarrier = false;

    }
    
}
