using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/**************************************************************************
Mount: UIGameEnd 
Function: To implement the logic of Game end scene
**************************************************************************/
public class GameEndManager : MonoBehaviour
{

    //--------------------------------------------------
    //Constant or static variables definition
    const float panelMoveTime = 0.4f;
    //--------------------------------------------------
    //Private Variables Definition
    RectTransform panel;
    Tween movePanel;

    //--------------------------------------------------
    //Unity Cycle
    private void Awake()
    {
        Init();
        movePanel.Restart();
        
    }
    void Start()
    {
        //GameManager.LoadScore("ScoreRoot2");   
    }

    // Update is called once per frame
    void Update()
    {

    }


    //--------------------------------------------------
    //Methods Definition
    void Init()
    {
        panel = GameObject.Find("ScorePanel").GetComponent<RectTransform>();
        movePanel = panel.DOAnchorPos3D(new Vector3(0.0f, 310.0f, 0.0f), panelMoveTime);
        movePanel.SetUpdate(true);
        movePanel.OnComplete(ButtonManager.LoadBtnPlay);
    }
}
