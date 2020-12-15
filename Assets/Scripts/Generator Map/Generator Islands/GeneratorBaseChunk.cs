using UnityEngine;

public class GeneratorBaseChunk : MonoBehaviour
{
	[Header("All Base Chunk")]
	public BaseChunk[] Chunks;
	
	public int IndexBaseChunk { get{ return _indexCreateChunk; } }
	public DataObject BaseChunkData { get{ return _chunkData; } }
	
	private int _indexCreateChunk;
	private DataObject _chunkData;
	
	public void Create(Vector3 position)
	{
		_indexCreateChunk = RandomValue.NumberInt(Chunks.Length);
		
		var chunk = Chunks[_indexCreateChunk];
		
		chunk.Data.id = _indexCreateChunk;
		chunk.Data.Position = position;
		chunk.Data.Rotation = RandomValue.RotationY();
		
		_chunkData = chunk.Data;
		
		Instantiate(chunk.Chunk, chunk.Data.Position,chunk.Data.Rotation);
	}
}