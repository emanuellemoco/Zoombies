using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGun : MonoBehaviour
{
    public int requiredPoints;
    bool isPlayerNearby;
    public int weaponIndex;

    int radius = 5;

    GameManager gm;

    // public Collider[] currentWallGun; 
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerNearby = false;
        // Collider[] hitColliders = Physics.OverlapSphere(Vector3.zero, radius);
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in hitColliders){
            Debug.Log(col.tag);   
            if (col.tag == "Player"){ 
                Debug.Log("PlayerNearby");
                isPlayerNearby = true;}
        }

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F)){
            WeaponSwitching.SelectWeapon(weaponIndex);
        }


        //if  (Input.GetKeyDown(KeyCode.F) && gm.points >= requiredPoints)
          //  WeaponSwitching.SelectWeapon(1);
        
    }

        void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }
}
