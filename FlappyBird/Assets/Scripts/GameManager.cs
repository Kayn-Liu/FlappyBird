using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**************************************************************************
//Mount: @GameManager
//Function: An entry point of the game and the manager of all scenes
**************************************************************************/


public class GameManager : MonoBehaviour
{
    //--------------------------------------------------
    //Variables Definition
    Controller_Mask myMask;

    public static int score;

    //--------------------------------------------------
    //Unity Cycle
    private void Awake()
    {       
        Init();
        myMask.CallTheMask(MaskType.black);
    }
    //--------------------------------------------------
    //Methods Definition

    //Use this to initialize the current scene
    public  void Init()
    {
        GameStates.CurrState = States.Start;
        //Load the mask
        LoadMask();

        ButtonManager.LoadBtnPlay(); //get the play button
        GetBird("PlayerRoot"); //get the bird
        GetBackground(); // get background
    }

    public static void LoadScene(States state)
    {
        string stStr = state.ToString();
        GameObject UIGameObj = Resources.Load(@"Prefabs\UIGame" + stStr) as GameObject;
        UIGameObj = Instantiate(UIGameObj);
        UIGameObj.name = "UIGame" + stStr;
        UIGameObj.transform.SetParent(GameObject.Find("UIGame"+stStr+"Root").transform);
        Tools.ResetUI(UIGameObj);
    }

    public void LoadMask()
    {
        GameObject mask = Resources.Load<GameObject>(@"Prefabs\Mask");
        mask = Instantiate(mask);
        mask.name = "Mask";
        mask.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").transform);
        Tools.ResetUI(mask);
        myMask = mask.GetComponent<Controller_Mask>();
    }

    /// <summary>
    /// Use this to Get a bird into the scene
    /// </summary>
    /// <param name="root">Parent transform of the bird</param>
    /// <returns>Player bird</returns>
    public static GameObject GetBird(string root)
    {
        int temp = Random.Range(0, 3);
        GameObject g = Resources.Load(@"Prefabs\Bird" + temp.ToString()) as GameObject;
        g = Instantiate(g);
        g.GetComponent<RectTransform>().SetParent(GameObject.Find(root).transform);
        Tools.ResetUI(g);
        return g;
    }

    /// <summary>
    /// Randomly get background of day or night
    /// </summary>
    public static void GetBackground()
    {
        //Get background Image Component
        Image background = GameObject.Find("Background").GetComponent<Image>();
        int x = Random.Range(0, 2);
        background.sprite = Resources.Load<Sprite>(@"Arts\bg_" + x.ToString());
        background.SetNativeSize();
    }


    public static void LoadScore(string root)
    {
        GameObject g = Resources.Load<GameObject>(@"Prefabs\Score");
        g = Instantiate(g,GameObject.Find(root).transform);
        Tools.ResetUI(g);
    }

}
