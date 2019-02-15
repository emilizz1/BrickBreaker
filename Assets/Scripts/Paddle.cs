using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    [SerializeField] bool autoPlay = false;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        Cursor.visible = false;
    }

    void Update()
    {
        if (!autoPlay)
        {
            MousePlay();
        }
        else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        Vector3 BallPossition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(BallPossition.x, 0.82f, 15.18f);
        this.transform.position = paddlePos;
    }

    void MousePlay()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.82f * transform.localScale.x, 16f - 0.82f * transform.localScale.x);
        paddlePos.x = mousePosInBlocks;
        this.transform.position = paddlePos;
    }
}
