using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************
//Mount: UIBtnPlayAndRank
//Function: Manage the two buttons throughout the game
**************************************************************************/

public class ButtonManager : MonoBehaviour
{
    //--------------------------------------------------
    //Variables Definition
    GameObject BtnPlay;

    //--------------------------------------------------
    //Unity Cycle
    private void Start()
    {
        Init();
    }
    //--------------------------------------------------
    //Methods Definition
    public void Init()
    {
        BtnPlay = GameObject.Find("BtnPlay");

        UIEventListener.Get(BtnPlay).onClick += ButtonBehaviors.BtnPlay;
    }

    public static void LoadBtnPlay()
    {
        GameObject g = Resources.Load(@"Prefabs\BtnPlay") as GameObject;
        g = Instantiate(g);
        g.name = "BtnPlay";
        g.transform.SetParent(GameObject.Find("BtnRoot").transform);
        Tools.ResetUI(g);
    }

    public static void ClearButtons()
    {
        GameObject g = GameObject.Find("BtnPlay");
        Destroy(g);
    }
}
