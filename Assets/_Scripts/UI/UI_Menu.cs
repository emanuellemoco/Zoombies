using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{

    GameManager gm;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        
    }
    public void Play(){
        
        gm.ChangeState(GameManager.GameState.GAME);  
        
    }
}
