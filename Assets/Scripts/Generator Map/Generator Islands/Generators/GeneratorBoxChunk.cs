using UnityEngine;
using System.Collections.Generic;
using Chunks;

namespace Generators
{
	public class GeneratorBoxChunk : MonoBehaviour
	{
		[Header("All Chunk")]
		public List<BoxChunk> Chunks;
		
		public DataObjectBase[] BoxsDataChunk { get { return _boxsDataChunk; } }
		
		private DataObjectBase[] _boxsDataChunk;
		
		public void Create(Transform[] positions, Transform baseObject)
		{
			int numberPositions = positions.Length;
	
			// create temp variable
			var indexBoxChunk = new int[numberPositions];
			var boxChunks = new ChunkItem[numberPositions];

			_boxsDataChunk = new DataObjectBase[numberPositions]; 
			
			for (int i = 0; i < numberPositions; i++)
			{

				indexBoxChunk[i] = RandomValue.Number(Chunks.Count);
				boxChunks[i] = Chunks[indexBoxChunk[i]];
				
				boxChunks[i].Data.Id = indexBoxChunk[i];
				boxChunks[i].Data.Rotation = RandomValue.RotationY();
				boxChunks[i].Data.Position = positions[i].position;
				
				var temptrans = Instantiate(boxChunks[i].Chunk, baseObject).transform;
				
				CreateTrees(Chunks[boxChunks[i].Data.Id], temptrans);
				
				temptrans.position = boxChunks[i].Data.Position;
				temptrans.rotation = boxChunks[i].Data.Rotation = RandomValue.RotationY();;
				
				_boxsDataChunk[i] = boxChunks[i].Data; 
			}	
		}	
		
		public void CreateTrees(BoxChunk boxChunk, Transform parentPosition)
		{
			var temp = GeneratorTrees.Create(boxChunk, parentPosition);
			
		}
	}
}


