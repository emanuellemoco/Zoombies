using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeController : MonoBehaviour
{
    bool isPlayerNearby;
    bool isEnemyNearby;
    int radius = 3;
    private float _buildTimestamp = 0.0f; 
    private float _destroyTimestamp = 0.0f; 
    private float buildDelay = 0.5f;
    private float destroyDelay = 2.0f;

    EnemyController enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerNearby = false;
        isEnemyNearby = false;
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (Collider col in hitColliders){   
            if (col.tag == "Player")
                isPlayerNearby = true;
            if (col.tag == "Zombie"){
                Debug.Log("kesdfofsdij");
                isEnemyNearby = true;
                enemy = col.gameObject.GetComponent<EnemyController>();
            }
        }

        if (isPlayerNearby && Input.GetKey(KeyCode.F))
            buildBarrier();

        if (isEnemyNearby){
            destroyBarrier();

        }
    


   
    }

    void buildBarrier()
    {

        if ( Time.time - _buildTimestamp < buildDelay) 
            return;

        _buildTimestamp = Time.time;

        foreach (Transform barrier in transform)
        {
            if (!barrier.gameObject.activeSelf){
                barrier.gameObject.SetActive(true);
                return; }      
            
        }
    }


    void destroyBarrier()
    {
        if ( Time.time - _destroyTimestamp < destroyDelay)  
            return;
        _destroyTimestamp = Time.time; 
        
        foreach (Transform barrier in transform)
        {
            if (barrier.gameObject.activeSelf){
                barrier.gameObject.SetActive(false);
                enemy.DestroyBarrier(); 

                return; }      
            
        }
    }
    
}
