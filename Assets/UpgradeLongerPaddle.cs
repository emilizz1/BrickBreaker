using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLongerPaddle : Upgrade
{
    [SerializeField] float ValueToAdd;

    public override void GetUpgrade()
    {
        var paddleScale = FindObjectOfType<Paddle>().transform.localScale;
        paddleScale.x += ValueToAdd;
        FindObjectOfType<Paddle>().transform.localScale = paddleScale;
    }
}
