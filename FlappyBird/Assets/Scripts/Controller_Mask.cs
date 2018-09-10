using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/**************************************************************************
//Mount: Mask
//Function: Control the Mask GameObject to fade out and instantiate Game Scene when done
**************************************************************************/

public enum MaskType : byte
{
    black,
    white
}

public class Controller_Mask : MonoBehaviour
{
    //-----------------------------------------------------------
    //Variables definition
    Text logo;
    CanvasGroup myGroup;
    public static Sequence blackFade;
    public static Tween whiteFade;

    //--------------------------------------------------
    //Unity Cycle
    private void Awake()
    {
        Init();
    }
    //-----------------------------------------------------------
    //Functions Definition

    void Init()
    {
        logo = transform.GetChild(0).GetComponent<Text>();
        myGroup = GetComponent<CanvasGroup>();
        blackFade = DOTween.Sequence();
        whiteFade = DOTween.Sequence();
    }

    void CreateBlackFade()
    {
        //Reset the alpha of the Mask
        myGroup.alpha = 1;
        blackFade.Append(logo.DOColor(Color.yellow, 0.8f));
        blackFade.Append(logo.DOColor(Color.green, 0.8f));
        blackFade.Append(logo.DOFade(0.0f, 0.8f));
        blackFade.Append(myGroup.DOFade(0.0f, 1.2f));
        blackFade.SetUpdate(true);
    }

    void CreateWhiteFade()
    {
        myGroup.alpha = 1; //reset alpha
        GetComponent<Image>().color = Color.white; //set mask color to white
        whiteFade = myGroup.DOFade(0.0f, 0.5f);
        whiteFade.SetUpdate(true);
    }


    /// <summary>
    /// Call different mask with different effect
    /// </summary>
    /// <param name="mask">Mask Type: Black or White</param>
    public void CallTheMask(MaskType mask)
    {
        //Call the mask base on what type of mask you want
        switch (mask)
        {
            case MaskType.black:
                CreateBlackFade();
                blackFade.Restart();
                break;
            case MaskType.white:
                CreateWhiteFade();
                whiteFade.Restart();
                break;
        }
    }
}
