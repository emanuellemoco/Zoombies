using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallGun : MonoBehaviour
{

    public AudioClip chashSound;
    public int requiredPoints;

    public int ammorequiredPoints;

    public int reloadAmmo;
    bool isPlayerNearby;
    public int weaponIndex;

    public Text message;

    int radius = 5;

    GameManager gm;

    int currentWeapon;

    // public Collider[] currentWallGun; 
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = WeaponSwitching.getCurrentWeapon();
        isPlayerNearby = false; 
        // Collider[] hitColliders = Physics.OverlapSphere(Vector3.zero, radius);
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in hitColliders){
            if (col.tag == "Player"){ 
                Debug.Log("PlayerNearby");
                isPlayerNearby = true;}
        }
        if (isPlayerNearby && gm.gameState == GameManager.GameState.GAME && currentWeapon != weaponIndex){
            message.text = $"Press F to buy weapon.  {requiredPoints.ToString()} points";
            message.gameObject.SetActive(true);
        }
        else if (isPlayerNearby && gm.gameState == GameManager.GameState.GAME && currentWeapon == weaponIndex){
            message.text = $"Press F to buy ammo.  {ammorequiredPoints.ToString()} points";
            message.gameObject.SetActive(true);
        }
        else 
            message.gameObject.SetActive(false);


        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && gm.points >= requiredPoints && currentWeapon != weaponIndex){
            gm.points -= requiredPoints;
            WeaponSwitching.SelectWeapon(weaponIndex);
            AudioManager.PlaySFX(chashSound);
        }
        else if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && gm.points >= ammorequiredPoints && currentWeapon == weaponIndex){
            gm.points -= ammorequiredPoints;
            gm.totalBullets = reloadAmmo;
            AudioManager.PlaySFX(chashSound);
        }

    }

}
