using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/**************************************************************************
Mount: None
Function: To Store some global and useful tool for the whole game
**************************************************************************/
public static class Tools 
{
    /// <summary>
    /// To reset the RectTransform anchoredPosition and localScale to zero and one respectively
    /// </summary>
    /// <param name="g">the target Gameobject you want to reset</param>
    public static void ResetUI(GameObject g)
    {
        RectTransform rect = g.GetComponent<RectTransform>();
        rect.anchoredPosition3D = Vector3.zero;
        rect.localScale = Vector3.one;
    } 
}

public static class ButtonBehaviors
{
    public static void AniForClick(RectTransform rect)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(rect.DOScale(1.2f, 0.08f));
        seq.Append(rect.DOScale(1.0f, 0.08f));

        seq.Restart();
    }

    public static void BtnPlay(RectTransform rect)
    {
        Time.timeScale = 1.0f;
        GameStates.CurrState = States.Play;
        ButtonManager.ClearButtons();
        GamePlayManager.isFirst = true;
        GameManager.score = 0;
    }

}
