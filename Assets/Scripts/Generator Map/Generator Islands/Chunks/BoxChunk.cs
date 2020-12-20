using UnityEngine;

namespace Chunks
{
	public class BoxChunk : MonoBehaviour
	{
		[HideInInspector]
		public DataObject Data;
		[Header("Box Chunk")]
		public GameObject Chunk;
		[Header("Trees Position")]
		public Transform[] TreesPosition;
		
		[Header("Details For Box Chunk")]
		public ChunkPrefabs Prefab;
		public ChunkPrefabsPosition PrefabsPosition;
	}
}
