using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;

    public void Start(){
        gm = GameManager.GetInstance();
        gm.points = 0;
    }

    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
