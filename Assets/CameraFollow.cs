using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float distance;
	public float offset;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + distance, target.transform.position.z - offset);

		//this.transform.position 
	}
}
