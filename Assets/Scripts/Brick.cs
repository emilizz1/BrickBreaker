using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public GameObject smoke;
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	public AudioClip crack;

    private bool isBreakable;
    private int timesHit;
    private LevelManager levelManager;

    void Start ()
    {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			brickCount ++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position,0.75f);
		if (isBreakable)
        {
			HandleHits ();
		}
	}
	void HandleHits()
	{
		timesHit++;
		if (timesHit >= hitSprites.Length +1)
        {
			brickCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
            FindObjectOfType<UpgradeSpawner>().SpawnRequest(transform.position);
			Destroy (gameObject);
		}
        else
        {
			LoadSprites ();
		}
	}

	void PuffSmoke()
    {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        var smakePuffParticles = smokePuff.GetComponent<ParticleSystem>().main;
        smakePuffParticles.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites()
	{
		int index = timesHit-1;
		if (hitSprites [index])
        {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [index];
		}
	}
}
