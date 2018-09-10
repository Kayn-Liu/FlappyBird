using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************************************************************************
Mount: Pipes
Function: To move the pipe and some colider logic
**************************************************************************/
public class MovePipe : MonoBehaviour
{
    //--------------------------------------------------
    //Variables Definition
    [Range(1,5)]
    public float speed = 180.0f;

    Vector3 pos;

    //--------------------------------------------------
    //Unity Cycle
    void Update()
    {
        pos = transform.localPosition;
        transform.localPosition = new Vector3(pos.x - speed * Time.deltaTime, pos.y, 0);
    }
}
