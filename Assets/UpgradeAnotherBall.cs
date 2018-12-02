using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAnotherBall : Upgrade
{
    [SerializeField] GameObject ball;
    [SerializeField] float extraHeight = 0.5f;

    public override void GetUpgrade()
    {
        Vector2 spawnPos = FindObjectOfType<Paddle>().transform.position;
        spawnPos.y += extraHeight;
        Instantiate(ball, spawnPos, Quaternion.identity);
    }
}
