using UnityEngine;
using System.Collections;

public class RollerBallMovement : MonoBehaviour 
{
	private Rigidbody rb;
	public float speedModifier = 1.0f;

	void Start()
	{
		rb = GetComponentInChildren<Rigidbody>();
	}

	void FixedUpdate()
	{
		float moveHoriz = Input.GetAxis("Horizontal");
		float moveVert = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHoriz , 0.0f, moveVert);

		rb.AddForce(movement * speedModifier);
	}
}
