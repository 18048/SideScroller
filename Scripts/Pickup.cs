using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	//make a container for the heads up display
	//pancam hud;

	public int scoreValue =  1;

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") 
		{
			Destroy(this.gameObject);
			ScoreManager.score += scoreValue;
		}
		
	}
}