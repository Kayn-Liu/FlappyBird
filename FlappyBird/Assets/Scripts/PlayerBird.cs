using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/**************************************************************************
Mount: PlayerRoot (Empty GameObject used to setting the root position for bird)
Function: To Store some basic information of the player bird and its logic
**************************************************************************/


public class PlayerBird : MonoBehaviour
{    
    //--------------------------------------------------
    //Constant or static variables definition
    const float birdStartGravity = 1.5f;
    const float birdDeadGravity = 1.7f;
    const float angularDrag = 5.0f;




    //--------------------------------------------------
    //Privare Variables Definition
    RectTransform Player;
    Rigidbody2D rdBird;
    Tween rotateBirdHeadUp;
    public Tween rotateBirdHeadDown;
    bool isClicked = false;

    [Range(1, 5)]
    public float speed = 4.5f;
    //--------------------------------------------------
    //Unity Cycle
    private void Awake()
    {
        Player = GameObject.Find("FlappyRoot").transform.GetChild(0).GetComponent<RectTransform>();
        rotateBirdHeadUp = Player.DORotate(new Vector3(0.0f, 0.0f, 35.0f), 0.35f);
        rotateBirdHeadDown =
            Player.DORotate(new Vector3(0.0f, 0.0f, -90.0f), 0.5f).SetDelay(0.5f).SetUpdate(true);

    }

    void Update()
    {
        float y = Player.anchoredPosition.y;

        if (!isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                if (rdBird == null)
                {
                    AddRigidbodyToBird();
                }
                rdBird.velocity = new Vector2(0, speed);
                rotateBirdHeadUp.Restart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                rotateBirdHeadDown.Restart();
            }

            isClicked = false;
        }
    }
    //--------------------------------------------------
    //Methods Definition
    public void AddRigidbodyToBird()
    {
        rdBird = Player.gameObject.AddComponent<Rigidbody2D>();
        rdBird.gravityScale = birdStartGravity;
        rdBird.angularDrag = angularDrag;
    }

}
