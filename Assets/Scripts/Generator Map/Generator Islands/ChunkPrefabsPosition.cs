using UnityEngine;

[System.Serializable]
public struct ChunkPrefabsPosition
{
	[Header("Position and Rotation")]
	public Transform[] Rocks;
	public Transform[] Trees;
	public Transform[] Grasses;
	public Transform[] Detailses;
}
