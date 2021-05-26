using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour
{
    public int damage;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        
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
            EnemyController controller = col.gameObject.GetComponent<EnemyController>();
            if (controller != null)
                controller.TakeDamage(damage);
                gm.points += 10;

                Debug.Log("Doing damage");
            }
        Debug.Log("Destroyed?");
        Destroy(this.gameObject);
    }
}
