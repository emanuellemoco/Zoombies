using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Pause : MonoBehaviour
{

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    } 

    public void Resume()
    {
        Time.timeScale = 1;
        gm.ChangeState(GameManager.GameState.GAME);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
    public void Options()
    {
        gm.ChangeState(GameManager.GameState.OPTIONS);
    }

    
}
