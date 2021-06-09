using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ammo : MonoBehaviour
{
    GameManager gm;
    Text message;
    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<Text>();
        gm = GameManager.GetInstance();   
    }

    // Update is called once per frame
    void Update()
    {
        message.text = $"`{gm.bullets}/{gm.totalBullets}";
    }
}
