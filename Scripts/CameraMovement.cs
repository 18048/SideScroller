using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
		public float movementSpeed;
		
		
		
		void Update()
		{
			float x = Input.GetAxis ("Horizontal");
			Vector2 movement = new Vector2 (x, 0f);
			transform.Translate (movement * movementSpeed * Time.deltaTime);
		}
	}