﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.0f); //gameObject is current gameObject
        Debug.Log(collision.gameObject.name);
    }
}
