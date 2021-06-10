using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{   
    private static WeaponSwitching _instance;

    private int currentWeaponIndex = 0;

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
            if(index == i){
                _instance.currentWeaponIndex = index;
                weapon.gameObject.SetActive(true);}
            else
                weapon.gameObject.SetActive(false);
            
            i++;
        }
    }

    public static int getCurrentWeapon()
    {   
        return _instance.currentWeaponIndex;
    }

}
