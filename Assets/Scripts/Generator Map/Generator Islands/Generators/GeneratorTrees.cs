using UnityEngine;
using System.Collections.Generic;
using Chunks;

namespace Generators
{
	public class GeneratorTrees : MonoBehaviour
	{
		[Header("Trees")]
		public ChunkItem[] TreeItems;
		
		public List<DataObjectFull> TreesData{ get{ return _treesData; } }
		private List<DataObjectFull> _treesData = new List<DataObjectFull>(); 
		
		public void Create(GeneratorBoxChunk boxChunk)
		{
			for (int i = 0; i < boxChunk.BoxsDataChunk.Length; i++)
			{
				for (int x = 0; x < boxChunk.Chunks[ boxChunk.BoxsDataChunk[i].id].TreesPosition.Length; x++)
				{
					var tempData = new DataObjectFull();
					
					tempData.Position = boxChunk.Chunks[ boxChunk.BoxsDataChunk[i].id].TreesPosition[x].position;
					tempData.id = RandomValue.Number(TreeItems.Length);
					tempData.Rotation = RandomValue.RotationY();
				
					_treesData.Add(tempData);
					Instantiate(TreeItems[_treesData[i + x].id].Chunk, _treesData[i + x].Position, _treesData[i + x].Rotation);
				}
			}
		}
		
		public void Create(GeneratorBaseChunk baseChunk)
		{
			//_treesData = new DataObjectPosition[1];
			
		}
	}
}


