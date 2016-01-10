using UnityEngine;
using System.Collections;

public class TestFire : MonoBehaviour 
{
	public GameObject source;
	public GameObject destination;
	public Rigidbody grenadePrefab;
	public float grenadeSpeed;

	private Vector3 aimVector;

	void Start()
	{
		
	}

	void Update()
	{

		aimVector = destination.transform.position - source.transform.position;
		Debug.DrawRay(source.transform.position, aimVector, Color.white);

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			FireGrenade();
		}
	}

	void FireGrenade()
	{
		Rigidbody grenadeClone; 
		grenadeClone = Instantiate(grenadePrefab, destination.transform.position,transform.rotation) as Rigidbody;

		if(grenadeClone != null)
			print("its here");
		else
			print("Lost it dude");
		//grenadeClone.AddForce(aimVector
	}
}