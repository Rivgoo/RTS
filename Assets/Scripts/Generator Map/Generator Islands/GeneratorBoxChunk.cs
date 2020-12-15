using UnityEngine;

public class GeneratorBoxChunk : MonoBehaviour
{
	[Header("All Box Chunk")]
	public BoxChunk[] Chunks;
	public BoxChunk[] SmallIslandChunks;
	
	public DataObject[] BoxsData { get { return _boxsData; } }
	private DataObject[] _boxsData;
	
	public void Create(Transform[] positions, bool isSmallIslandChunk = false)
	{
		if (isSmallIslandChunk)
		{
			if (SmallIslandChunks.Length == 0) 
			{
				throw new System.ArgumentNullException("SmallIslandChunks","Add positions for create Box!");
			}
		}
		else
		{
			if (Chunks.Length == 0) 
			{
				throw new System.ArgumentNullException("Chunks","Add positions for create Box!");
			}
		}
		
		int numberPositions = positions.Length;

		// create temp variable
		var indexBoxChunk = new int[numberPositions];
		var boxChunks = new BoxChunk[numberPositions];
		_boxsData = new DataObject[numberPositions];
		
		for (int i = 0; i < numberPositions; i++)
		{
			if (!isSmallIslandChunk)
			{
				indexBoxChunk[i] = RandomValue.NumberInt(Chunks.Length);
				boxChunks[i] = Chunks[indexBoxChunk[i]];
			}
			else
			{
				indexBoxChunk[i] = RandomValue.NumberInt(SmallIslandChunks.Length);
				boxChunks[i] = SmallIslandChunks[indexBoxChunk[i]];
			}
			
			boxChunks[i].Data.id = indexBoxChunk[i];
			boxChunks[i].Data.Position = positions[i].position;
			boxChunks[i].Data.Rotation = RandomValue.RotationY();
			
			_boxsData[i] = boxChunks[i].Data;
			
			Instantiate(boxChunks[i].Chunk, boxChunks[i].Data.Position, boxChunks[i].Data.Rotation);
		}
		
	}	
}
