using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;

    public Text message;

    public void Start(){
        gm = GameManager.GetInstance();
        message.text =  $"You survived  {gm.round.ToString()} rounds";
    }

    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
