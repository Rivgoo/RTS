using UnityEngine;
using Chunks;

namespace Generators
{
	public class GeneratorBoxChunk : MonoBehaviour
	{
		[Header("All Box Chunk")]
		public BoxChunk[] Chunks;
		public BoxChunk[] SmallIslandChunks;
		
		public DataObject[] BoxsDataChunk { get { return _boxsDataChunk; } }
		public DataObject[] BoxsDataSmallIsnland{ get { return _boxsDataSmallIsnlands; } }

		private DataObject[] _boxsDataChunk;
		private DataObject[] _boxsDataSmallIsnlands;
		
		public void Create(Transform[] positions, Transform baseObject, bool isSmallIslandChunk = false)
		{
			CheckNullInArray(isSmallIslandChunk);
			
			int numberPositions = positions.Length;
	
			// create temp variable
			var indexBoxChunk = new int[numberPositions];
			var boxChunks = new BoxChunk[numberPositions];
			
			if (!isSmallIslandChunk)
			{
				_boxsDataChunk = new DataObject[numberPositions];
			}
			else
			{
				_boxsDataSmallIsnlands = new DataObject[numberPositions];	
			}
			 
			
			for (int i = 0; i < numberPositions; i++)
			{
				if (!isSmallIslandChunk)
				{
					indexBoxChunk[i] = RandomValue.Number(Chunks.Length);
					boxChunks[i] = Chunks[indexBoxChunk[i]];
					
					boxChunks[i].Data.id = indexBoxChunk[i];
					boxChunks[i].Data.Rotation = RandomValue.RotationY();
				
					_boxsDataChunk[i] = boxChunks[i].Data;
				}
				else
				{
					indexBoxChunk[i] = RandomValue.Number(SmallIslandChunks.Length);
					boxChunks[i] = SmallIslandChunks[indexBoxChunk[i]];
					
					boxChunks[i].Data.id = indexBoxChunk[i];
					boxChunks[i].Data.Rotation = RandomValue.RotationY();
				
					_boxsDataSmallIsnlands[i] = boxChunks[i].Data;
				}
				
				Instantiate(boxChunks[i].Chunk, positions[i].position, boxChunks[i].Data.Rotation, baseObject);
			}
			
		}	
		
		private void CheckNullInArray(bool isSmallIslandChunk)
		{
			if (isSmallIslandChunk && SmallIslandChunks.Length == 0)
			{
				throw new System.ArgumentNullException("SmallIslandChunks","Add positions for create Box!");
			}
			else if (Chunks.Length == 0) 
			{
	
				throw new System.ArgumentNullException("Chunks","Add positions for create Box!");
			}
		}
	}
}


