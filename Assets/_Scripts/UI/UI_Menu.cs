using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Menu : MonoBehaviour
{

    GameManager gm;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        
    }
    public void Play(){
        Time.timeScale = 1;
        gm.ChangeState(GameManager.GameState.GAME);  
        
    }

    public void Options(){

        gm.ChangeState(GameManager.GameState.OPTIONS);
    }

    public void Quit(){
        Application.Quit();
    }

}
