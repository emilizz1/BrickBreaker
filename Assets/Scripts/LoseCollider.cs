﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D collider)
	{
        if (collider.gameObject.GetComponent<Ball>() && FindObjectsOfType<Ball>().Length <= 1)
        {
            FindObjectOfType<LevelManager>().LoadLevel(2);
        }
        Destroy(collider.gameObject);
    }
}
