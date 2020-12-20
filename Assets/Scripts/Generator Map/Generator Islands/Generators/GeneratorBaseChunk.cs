using UnityEngine;
using Chunks;

namespace Generators
{
	public class GeneratorBaseChunk : MonoBehaviour
	{
		[Header("All Base Chunk")]
		public BaseChunk[] Chunks;
	
		public DataObject BaseChunkData { get{ return _chunkData; } }
		
		private DataObject _chunkData;
		
		public void Create(Transform baseObject)
		{
			_chunkData.id = RandomValue.Number(Chunks.Length);
			_chunkData.Rotation = RandomValue.RotationY();
			
			Instantiate(Chunks[_chunkData.id].Chunk, new Vector3(0,0,0),_chunkData.Rotation,  baseObject);
		}
	}
}