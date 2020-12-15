using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
public class RestrictionTreePlacement : MonoBehaviour {

	public float Radius;
	
	private SphereCollider col;
	
	public bool Distanse(Vector3 target, Vector3 basePosition)
	{
		return Math.Sqrt(Math.Pow(target.x - basePosition.x, 2) + Math.Pow(target.z - basePosition.z, 2)) <= Radius;
	}
	
	public void VisualColider()
	{
		col = GetComponent<SphereCollider>();
		col.radius = Radius;
	}
}

