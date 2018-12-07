using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLongerPaddle : Upgrade
{
    [SerializeField] float ValueToAdd;
    [SerializeField] float MaxPaddleValue;

    public override void GetUpgrade()
    {
        var paddleScale = FindObjectOfType<Paddle>().transform.localScale;
        if (paddleScale.x < MaxPaddleValue)
        {
            paddleScale.x += ValueToAdd;
            FindObjectOfType<Paddle>().transform.localScale = paddleScale;
        }
    }
}
