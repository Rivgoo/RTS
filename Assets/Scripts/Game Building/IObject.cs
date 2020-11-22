using UnityEngine;

public interface IObject
{
	ObjectData Object {get; set;}
	
	bool CheckCreateObject();
	void CreateObjectOnScreen();
	bool CheckResources();
	void CreateObject();
	void Destroy();

}

[System.Serializable]
public struct ObjectData
{
	public Transform transform;
	
	public int IdObject;
	public int IdInWorld;
	public int Health;
	
	public MeshRenderer Renderer;

	public Season ObjectSeason;
}