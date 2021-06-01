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
    private bool isPlayerNearby = false;
    PlayerController player;

    public GameObject playerPos;

    public float attackDelay = 4;
    private float _attackTimestamp = 0.0f; 

    int radius = 3;
    // Start is called before the first frame update
    void Start()
    {
        life = 6;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in hitColliders){
            if (col.tag == "Player"){ 
                player = col.gameObject.GetComponent<PlayerController>();
                isPlayerNearby = true;}
        }

        if (isPlayerNearby){
            Attack();

        }

        if (!isDead && !isBarrier && !isPlayerNearby)
            agent.SetDestination(playerPos.transform.position);
        
    }


    private void Attack(){
        if ( Time.time - _attackTimestamp < attackDelay) 
            return;
        _attackTimestamp = Time.time; 
        player.TakeDamage();
        StartCoroutine(AttackRoutine());
    }
    public void TakeDamage(int damage)
    {
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
        StartCoroutine(Headbutt());

    }
    IEnumerator Headbutt() {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        isBarrier = false;

    }

    IEnumerator AttackRoutine() {
        animator.SetTrigger("Attack");        
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        isPlayerNearby = false;
    }
    
}
