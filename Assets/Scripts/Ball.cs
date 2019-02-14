using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [SerializeField] float clampValue = 10f;

	private Paddle padle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
    Rigidbody2D rigidbody;
    
	void Start ()
    {
		padle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - padle.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
		if(!hasStarted)
		{
			this.transform.position = padle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0))
            {
				hasStarted = true;
                rigidbody.velocity = new Vector2(Random.Range(-2f, 2f), 10f);
			}
		}
        else if(rigidbody.velocity.magnitude < clampValue / 2)
        {
            rigidbody.AddForce(new Vector2(10f, 10f));
        }

	}

    void OnCollisionEnter2D (Collision2D collision)
	{
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
		if (hasStarted)
        {
			GetComponent<AudioSource>().Play ();
            rigidbody.velocity += tweak;
            rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, clampValue);
		}
	}
}
