using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShorterPaddle : Upgrade
{

    [SerializeField] float ValueToRemove;
    [SerializeField] float MinPaddleValue;

    public override void GetUpgrade()
    {
        var paddleScale = FindObjectOfType<Paddle>().transform.localScale;
        if (paddleScale.x > MinPaddleValue)
        {
            paddleScale.x -= ValueToRemove;
            FindObjectOfType<Paddle>().transform.localScale = paddleScale;
        }
    }
}
