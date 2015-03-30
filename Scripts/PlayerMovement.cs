using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float movementSpeed;
	public float scaleVar;
	public float score = 0f;

	public AudioClip[] audioClip;
	
	private ParallaxController _parallaxController;


	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip [clip];
		GetComponent<AudioSource>().Play ();
	}



	void Awake()
	{
		_parallaxController = GetComponent<ParallaxController> ();
	}
	
	void Update()
	{
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (x, y, 0f);
		Vector2 movementParallax = new Vector2(x, 0f); //prevents background from moving up and down
		transform.Translate (movement * movementSpeed * Time.deltaTime);
		_parallaxController.Scroll (movementParallax *= -1);

		if(Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) 
		{
			Vector3 scale = transform.localScale;
			scale.x = (-1f * scaleVar);
			scale.y = (1f * scaleVar);
			transform.localScale = scale;
		}
		if(Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) 
		{
			Vector3 scale = transform.localScale;
			scale.x = (1f * scaleVar);
			scale.y = (1f * scaleVar);
			transform.localScale = scale;
		}
	}

	void OnTriggerEnter (Collider col) {

		if (col.tag == "Enemy") {
			if (score < 11) {
				Destroy(this.gameObject);

			}
		    if (score > 10) {
				PlaySound (0);
				score = (score + 3);
				Vector3 scale = transform.localScale;
				scaleVar = scaleVar + 0.24f;
				if (scale.x > 0.99)
				{
					scale.x = (1f * scaleVar);
					scale.y = (1f * scaleVar);
					transform.localScale = scale;
				}
				else 
				{
					scale.x = (-1f * scaleVar);
					scale.y = (1f * scaleVar);
					transform.localScale = scale;
				}
				
				movementSpeed = movementSpeed + 0.45f;
			}
		}



		if (col.tag == "Pickup") {
			PlaySound (1);
			score = (score + 1);
			Vector3 scale = transform.localScale;
			scaleVar = scaleVar + 0.08f;
			if (scale.x > 0.99)
			{
				scale.x = (1f * scaleVar);
				scale.y = (1f * scaleVar);
				transform.localScale = scale;
			}
			else 
			{
				scale.x = (-1f * scaleVar);
				scale.y = (1f * scaleVar);
				transform.localScale = scale;
			}
			
			movementSpeed = movementSpeed + 0.15f;
		}
	}
}