using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
 
    public enum GameState { MENU, GAME, PAUSE, ENDGAME, OPTIONS };
    
    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }

    public int points = 0;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;


    public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

    private GameManager()
   {
       gameState = GameState.MENU;
       lastState = GameState.MENU;

   }
   
   public void ChangeState(GameState nextState)
    {
        lastState = gameState;
        gameState = nextState;
        changeStateDelegate();
    }

    public void Reset(){
        points = 0;
    }
}