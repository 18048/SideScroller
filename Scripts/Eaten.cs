using UnityEngine;
using System.Collections;

public class Eaten : MonoBehaviour {

	public int scoreValue =  3;
	
	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") 
		{
			Destroy(this.gameObject);
			ScoreManager.score += scoreValue;
		}
		
	}
}