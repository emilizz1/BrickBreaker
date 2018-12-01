using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MousePlay ();
		} else {
			AutoPlay();
		}
	}
	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		Vector3 BallPossition = ball.transform.position;
		paddlePos.x = Mathf.Clamp(BallPossition.x,0.82f,15.18f);
		this.transform.position = paddlePos;
	}

	void MousePlay()
	{
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		float mousePosInBlocks = Mathf.Clamp( Input.mousePosition.x / Screen.width * 16, 0.82f, 15.18f);
		paddlePos.x = mousePosInBlocks;
		this.transform.position = paddlePos;
	}

}
