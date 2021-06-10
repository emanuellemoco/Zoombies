using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorBehaviour : MonoBehaviour
{
    public int requiredPoints;

    private bool isPlayerNearby;

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
        isPlayerNearby = false;
        // Collider[] hitColliders = Physics.OverlapSphere(Vector3.zero, radius);
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in hitColliders){
            if (col.tag == "Player"){ 
                isPlayerNearby = true;}
        }
        if (isPlayerNearby && gm.gameState == GameManager.GameState.GAME){
            message.text = $"Press F to unlock the door.  {requiredPoints.ToString()} points";
            message.gameObject.SetActive(true);
        }
        else 
            message.gameObject.SetActive(false);


        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && gm.points >= requiredPoints){
            gm.points -= requiredPoints;
            message.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }

}
