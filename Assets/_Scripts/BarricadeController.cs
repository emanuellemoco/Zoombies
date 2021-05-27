using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if  (Input.GetKeyDown(KeyCode.F))
            buildBarrier();        
    }

    void buildBarrier()
    {
        foreach (Transform barrier in transform)
        {
            if (!barrier.gameObject.activeSelf){
                barrier.gameObject.SetActive(true);
                return; }      
            
        }
    }
    
}
