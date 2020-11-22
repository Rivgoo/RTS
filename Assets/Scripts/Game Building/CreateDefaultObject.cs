using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDefaultObject
{
	private static Vector3 _movePosition;
	
	public static Quaternion RotateObject(Transform target)
	{
		return target.localRotation;
	}
	
	public static Vector3 MoveObject()
	{
		var plane = new Plane(Vector3.up, Vector3.zero);
				
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
		float entry;
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 450))
		{
			_movePosition = hit.point;
		}
		else if (plane.Raycast(ray, out entry))
		{
			_movePosition = ray.GetPoint(entry);
		}
				
		return  _movePosition;
	}
}
