using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{   
    private static WeaponSwitching _instance;

    //Idea of Weapon Switching from Brackeys (obrigado William!)

    void Awake()
   {
        _instance = this;
   }

    public static void SelectWeapon(int index)
    {   
        int i = 0;
        foreach (Transform weapon in _instance.transform)
        {
            Debug.Log("FOREACH");
            if(index == i)
                weapon.gameObject.SetActive(true);
            else{
                Debug.Log("NOT i");
                weapon.gameObject.SetActive(false);}
            
            i++;
        }
    }

}
