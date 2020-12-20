using UnityEngine;

namespace Chunks
{
	[System.Serializable]
	public struct ChunkPrefabs
	{
		[Header("Prefabs")]
		public GameObject[] Rocks;
		public GameObject[] Trees;
		public GameObject[] Grasses;
		public GameObject[] Detailses;
	}
}
