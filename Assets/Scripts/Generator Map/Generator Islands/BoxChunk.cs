using UnityEngine;

public class BoxChunk : MonoBehaviour
{
	[HideInInspector]
	public DataObject Data;
	[Header("Box Chunk")]
	public GameObject Chunk;
	
	[Header("Details For Box Chunk")]
	public ChunkPrefabs Prefab;
	public ChunkPrefabsPosition PrefabsPosition;
}
