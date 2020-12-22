using UnityEngine;

namespace Chunks
{
	public class ChunkItem : MonoBehaviour
	{
		[HideInInspector]
		public DataObjectBase Data;
		[Header("Chunk")]
		public GameObject Chunk;
	}
}
