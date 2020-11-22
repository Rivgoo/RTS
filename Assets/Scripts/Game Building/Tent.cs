using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour, IObject
{

	public ObjectData Object { get { return _object; } set { _object = value; } }
	
	public bool IsEdit;
	[SerializeField]
	private ObjectData _object;
	
	private bool IsMoveObject;

	public bool CheckCreateObject()
	{
		return true;
	}
	
	public bool CheckResources()
	{
		return true;
	}
	
	public void CreateObjectOnScreen()
	{
		if (IsEdit) {		
			transform.position = new Vector3(CreateDefaultObject.MoveObject().x, CreateDefaultObject.MoveObject().y + 0.49f, CreateDefaultObject.MoveObject().z);
		}
	}
	public void CreateObject()
	{
			IsEdit = false;	
	}
	public void Destroy()
	{
		Destroy(GetComponent<GameObject>());
	}
	
	private void Update()
	{
		CreateObjectOnScreen();
		
		if (IsEdit && !MoveCamera.IsMoveCamera)
		{	
			if (Input.GetMouseButtonUp(0))
			{	
				CreateObject();
			}
		}
		
	}
	
	private void Start()
	{
		//Object.Renderer.enabled = false;
		//_object.transform = GetComponentInChildren<Transform>();
		//_object.Renderer = GetComponent<MeshRenderer>();
	}
}
