using UnityEngine;

namespace Chunks
{
	public class BoxChunk : ChunkItem
	{
		[Header("Trees Prefab")]
		public ChunkItem[] Trees;
		[Header("Trees Position")]
		public Transform[] TreesPosition;
		
		[Header("Details For Box Chunk")]
		public ChunkPrefabs Prefab;
		public ChunkPrefabsPosition PrefabsPosition;
	}
}
