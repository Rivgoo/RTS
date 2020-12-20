using UnityEngine;

namespace Chunks
{
	public class BaseChunk : MonoBehaviour
	{
		[HideInInspector]
		public DataObject Data;
		[Header("Base Chunk")]
		public GameObject Chunk;
		
		[Header("Positon For Box Chunk")]
		public Transform[] PositionBoxChunk;
		
		[Header("Positon For Small Chunk")]
		public Transform[] PositionSmallChunk;
		
		[Header("Details For Base Chunk")]
		public ChunkPrefabs Prefab;
		public ChunkPrefabsPosition PrefabsPosition;
	}
}

