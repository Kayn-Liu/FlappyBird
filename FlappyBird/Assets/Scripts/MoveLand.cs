using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**************************************************************************
//Mount: Land
//Function: Keep the land moving every frame
**************************************************************************/


public class MoveLand : MonoBehaviour
{
    //--------------------------------------------------
    //Variables Definition
    [Range(0.0f,5.0f)]
    public float speed = 3.2f;
    Vector2 movement;
    float x;
    RawImage land;
    //--------------------------------------------------
    //Unity Cycle
    // Use this for initialization
    void Start()
    {
        land = GetComponent<RawImage>();
        land.uvRect = new Rect(1.0f, 0.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        x = GetComponent<RawImage>().uvRect.x;
        land.uvRect = new Rect(speed * 0.3f*Time.deltaTime + land.uvRect.x, 0, 1, 1);
    }
}
