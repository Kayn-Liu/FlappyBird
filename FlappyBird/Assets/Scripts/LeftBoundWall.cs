﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************
//Mount: LeftBound
//Function: Destory all triggers entered it
**************************************************************************/
public class LeftBoundWall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.transform.parent.gameObject);
    }
}
