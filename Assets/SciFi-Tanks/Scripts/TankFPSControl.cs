using UnityEngine;
using System.Collections;

public class TankFPSControl : MonoBehaviour
{
	public GameObject reticle;
	Transform pivot;
	Transform target;
	TankAnimator tank;
	public Transform aimAt;

	void Start ()
	{
		pivot = new GameObject ("Targeting Pivot").transform;
		pivot.position = transform.position + (transform.up );//* 3);
		pivot.parent = transform;
		target = new GameObject ("Target Reticle").transform;
		target.position = pivot.position + (Vector3.forward * 3);
		target.parent = pivot;
		tank = GetComponent<TankAnimator> ();
		tank.target = target;
		//var r = Instantiate(reticle) as GameObject;
		//r.transform.parent = target;
		//r.transform.localPosition = Vector3.zero;
		//r.transform.LookAt(pivot);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		var speed = Input.GetAxis ("Vertical");
		var turnSpeed = Input.GetAxis ("Horizontal")*1.0f;
		// taken out of turn speed above Time.deltaTime*
		transform.Rotate (Vector3.up, turnSpeed);
		transform.Translate (Vector3.forward * speed * Time.deltaTime*5); 
		tank.forwardSpeed = speed*100;
		tank.turnSpeed = turnSpeed*100;
		//pivot.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
		pivot.LookAt(aimAt);
		//taken out of rotat above Time.deltaTime*
		//target.Translate(Vector3.up*Time.deltaTime*Input.GetAxis("Mouse Y")*10);
	}
	
	
}
