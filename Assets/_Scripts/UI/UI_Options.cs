using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Options : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
    
    public void Exit()
    {
        gm.ChangeState(gm.lastState);
    }
}
