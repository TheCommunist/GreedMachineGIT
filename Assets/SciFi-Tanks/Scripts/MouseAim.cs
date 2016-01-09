using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour 
{
	private Camera playerCamera;
	public GameObject visiblePoint;

	void Start()
	{
		playerCamera = GetComponent<Camera>();
	}

	void Update()
	{
		Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit))
		{
			visiblePoint.transform.position = hit.point;
		}

	}



//	public float distance = 50.0f;
//	public GameObject visiblePoint;
//
//	void FixedUpdate () 
//	{
//		CastRayToWorld();
//	}
//
//	void CastRayToWorld()
//	{
//		Ray ray = new Ray(Input.mousePosition, Vector3.down);//Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//
//		if(Physics.Raycast (ray, out hit, distance))
//		{
//			Debug.DrawLine(ray.origin, hit.point);
//			print("hi");
//		}
//
////		Vector3 point = ray.origin + (ray.direction * distance);
////		visiblePoint.transform.position = point;
////		print("World Point = " + point);
//	}

}
