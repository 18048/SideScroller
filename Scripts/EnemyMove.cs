using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float Kappa = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Kappa, 0, 0);
	}
}
