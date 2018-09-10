using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventListener : EventTrigger
{
    public delegate void onClickHandler(RectTransform rect);

    public onClickHandler onClick;

    RectTransform rect;

    public static UIEventListener Get(GameObject g)
    {
        UIEventListener listener = g.GetComponent<UIEventListener>();
        if (listener == null)
            listener = g.AddComponent<UIEventListener>();
        listener.rect = g.GetComponent<RectTransform>();
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null)
            onClick(rect);
    }
}
