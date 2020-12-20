using UnityEngine;

[System.Serializable]
public struct DataObject : IDataObject
{
	public int id { get; set;}
	public Quaternion Rotation {get; set;}
}

[System.Serializable]
public struct DataObjectFull : IDataObject
{
	public int id { get; set;}
	public Quaternion Rotation {get; set;}
	public Vector3 Position {get; set;}
}

interface IDataObject
{
	int id { get; set;}
	Quaternion Rotation { get; set;}
}