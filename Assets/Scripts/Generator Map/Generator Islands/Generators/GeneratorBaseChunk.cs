using UnityEngine;
using Chunks;

namespace Generators
{
	public class GeneratorBaseChunk : MonoBehaviour
	{
		[Header("All Base Chunk")]
		public BaseChunk[] Chunks;
	
		public DataObjectBase BaseChunkData { get{ return _chunkData; } }
		
		private DataObjectBase _chunkData;
		
		public void Create(Transform baseObject)
		{
			_chunkData.Id = RandomValue.Number(Chunks.Length);
			_chunkData.Rotation = RandomValue.RotationY();
			
			Instantiate(Chunks[_chunkData.Id].Chunk, new Vector3(0,0,0),_chunkData.Rotation,  baseObject);
		}
	}
}