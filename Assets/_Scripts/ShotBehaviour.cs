using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("Zombie")){
            Debug.Log("A zombie!");
            ZombieController controller = col.gameObject.GetComponent<ZombieController>();
            if (controller != null)
                controller.TakeDamage(damage);
                Debug.Log("Doing damage");
            }
        Debug.Log("Destroyed?");
        Destroy(this.gameObject);
    }
}
