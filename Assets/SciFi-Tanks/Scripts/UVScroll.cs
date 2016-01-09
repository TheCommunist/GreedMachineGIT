using UnityEngine;
using System.Collections;

public class UVScroll : MonoBehaviour {
	
	public Vector2 translation;
	
	Material material;
	
	void Start () {
		material = GetComponent<Renderer>().material;
	}
	
	void Update () {
		material.mainTextureOffset = material.mainTextureOffset + (translation * Time.deltaTime);
	}
}
