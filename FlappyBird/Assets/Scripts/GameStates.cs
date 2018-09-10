using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States : byte
{
    Start,
    Play,
    End
}

public static class GameStates
{
    private static States _currentState;

    public static States CurrState
    {
        get { return _currentState; }
        set
        {
            //Destroy the old scene
            Object.Destroy(GameObject.Find("UIGame" + _currentState.ToString()));
            GameManager.LoadScene(value); //load the new scene
            _currentState = value; //record the scene change
        }
    }
}
