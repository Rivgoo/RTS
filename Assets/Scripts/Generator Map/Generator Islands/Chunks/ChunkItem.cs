using UnityEngine;

namespace Chunks
{
	public class ChunkItem : MonoBehaviour
	{
		[HideInInspector]
		public DataObjectFull Data;
		[Header("Box Chunk")]
		public GameObject Chunk;
	}
}
