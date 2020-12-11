using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
public class RestrictionTreePlacement : MonoBehaviour {

	public float Radius;
	
	private SphereCollider col;
	
	public bool Distanse(Vector3 target)
	{
		//print("VID" + Math.Sqrt(Math.Pow(target.x - Centre.x, 2) + Math.Pow(target.y - Centre.y, 2)));

		return Math.Sqrt(Math.Pow(target.x - transform.position.x, 2) + Math.Pow(target.y - transform.position.y, 2)) <= Radius;
	}
	
	public void VisualColider()
	{
		col = GetComponent<SphereCollider>();
		col.radius = Radius;
	}
}

