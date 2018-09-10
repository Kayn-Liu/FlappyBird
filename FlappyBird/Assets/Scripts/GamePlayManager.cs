using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**************************************************************************
Mount: UIGamePlay 
Function: To implement the logic of Play scene
**************************************************************************/
public class GamePlayManager : MonoBehaviour
{
    //--------------------------------------------------
    //Private Variables Definition
    
    Controller_Mask myMask;
    //--------------------------------------------------
    //Public Variables Definition
    public static bool isOver = false;
    public static bool isFirst = true;

    private void Awake()
    {
        GameManager.GetBird("FlappyRoot");
    }

    //--------------------------------------------------
    //Unity Cycle
    void Start()
    {
        myMask = GameObject.Find("Mask").GetComponent<Controller_Mask>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isFirst)
            {
                GameObject.Find("LogoGetReady").SetActive(false);
                GameObject.Find("Tutorial").SetActive(false);
                GameObject.Find("PipeSpawnRoot").GetComponent<SpawnPipes>().enabled = true;
                GameManager.LoadScore("ScoreRoot");
                isFirst = false;
            }
        }

        if (isOver)
        {
            //Game Over Logic:
            //Call the white Mask
            myMask.CallTheMask(MaskType.white);
            //Stop the Game timer
            Time.timeScale = 0.0f;
            //Load the GameEnd Scene
            GameStates.CurrState = States.End;
            isOver = false;
        }
    }
}
