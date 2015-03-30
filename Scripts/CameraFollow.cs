using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	
	void Update ()
	{
		Vector3 position = transform.position;
		position.x = target.transform.position.x;
		transform.position = position;
	}
}
