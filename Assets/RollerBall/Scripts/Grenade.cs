using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour 
{
	public float delayTime = 1.0f;
	public float explosionForce;
	public float explosionRadius;

	void Start()
	{
		StartCoroutine(Explode());
	}

	IEnumerator Explode()
	{
		yield return new WaitForSeconds(delayTime);

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

		foreach(Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 100.0f);
			}
		}

		Destroy(gameObject);
	}
}
