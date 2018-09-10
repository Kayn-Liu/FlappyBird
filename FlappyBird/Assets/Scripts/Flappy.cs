using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************************************************************************
Mount: bird
Function: Mainly to deal with the collision logic of the bird
**************************************************************************/

public class Flappy : MonoBehaviour
{
    //--------------------------------------------------
    //Constant or static variables definition
    const string tagGameOver = "Finish";
    const string tagScore = "Score";

    //--------------------------------------------------
    //Public Variables Definition



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagScore))
        {
            //Score 
            GameManager.score++;
        }

        else if (collision.CompareTag(tagGameOver))
        {

            //Game Over: Tell the manager the game is over
            GamePlayManager.isOver = true;
        }
    }
}
