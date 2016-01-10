using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestFire : MonoBehaviour 
{
	public GameObject source;
	public GameObject destination;
	public Rigidbody grenadePrefab;
	public float grenadeSpeed;

	public int maxNumberOfFieldedGrenades= 1;
	List<GameObject> activeGrenades = new List<GameObject>();

	private Vector3 fireOrigin;

	private Vector3 aimVector;

	void Start()
	{
		
	}

	void Update()
	{

		aimVector = destination.transform.position - source.transform.position;
		Debug.DrawRay(source.transform.position, aimVector, Color.white);

		fireOrigin = new Vector3(source.transform.position.x + (Mathf.Clamp(aimVector.x, -1, 1)), source.transform.position.y, source.transform.position.z + (Mathf.Clamp(aimVector.z, -1 , 1)));

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			FireGrenade();
		}
	}

	void FireGrenade()
	{
		//check to see how many active grenades have been fired
		for(int i = 0; i < activeGrenades.Count; i++)
		{
			print(activeGrenades[i].gameObject);
			if(activeGrenades[i].gameObject == null)
				activeGrenades.RemoveAt(i);
		}

		print(activeGrenades.Count);
		if(activeGrenades.Count < maxNumberOfFieldedGrenades)
		{
			Rigidbody grenadeClone; 

			grenadeClone = Instantiate(grenadePrefab, fireOrigin, transform.rotation) as Rigidbody;

			if(grenadeClone != null)
			{
				grenadeClone.AddForce(aimVector *200);
				activeGrenades.Add( grenadeClone.gameObject);
			}
			else
				print("Lost grenade prefab reference");
		}

	}
}