using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGun : MonoBehaviour
{
    public int gunIndex;
    public int requiredPoints;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

        //if  (Input.GetKeyDown(KeyCode.F) && gm.points >= requiredPoints)
          //  WeaponSwitching.SelectWeapon(1);
        
    }
}
