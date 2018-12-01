using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private bool isBreakable;
	private int timesHit ;
	private LevelManager levelManager;

	public GameObject smoke;
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	public AudioClip crack;


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			brickCount ++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position,0.75f);
		if (isBreakable) {
			HandleHits ();
		}
	}
	void HandleHits()
	{
		timesHit++;
		if (timesHit >= hitSprites.Length +1) {
			brickCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites()
	{
		int index = timesHit-1;
		if (hitSprites [index]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [index];
		}
	}
}
