using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 offset;

	void Start()
	{
		offset = transform.position - followTarget.transform.position;
	}

	void Update () 
	{
		transform.position = followTarget.transform.position + offset;
	}
}
