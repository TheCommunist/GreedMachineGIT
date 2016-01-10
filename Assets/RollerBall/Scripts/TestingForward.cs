using UnityEngine;
using System.Collections;

public class TestingForward : MonoBehaviour 
{
	private Transform testObjectTrans;

	void Start()
	{
		testObjectTrans = gameObject.transform;
	}

	void Update()
	{
		Debug.DrawRay(testObjectTrans.position, Vector3.forward*20, Color.cyan);
	}

}
