using UnityEngine;
using System.Collections.Generic;
using Chunks;

namespace Generators
{
	public class GeneratorTrees : MonoBehaviour
	{
		public static DataObjectBase[] Create(BoxChunk boxChunk, Transform parentPosition)
		{
			var treesData = new DataObjectBase[boxChunk.TreesPosition.Length];
			
			int numberSpawnTrees = RandomValue.Number(boxChunk.TreesPosition.Length + 1);
			
			for (int x = 0; x < numberSpawnTrees; x++)
			{		
				treesData[x].Position = boxChunk.TreesPosition[x].position;
				treesData[x].Id = RandomValue.Number(boxChunk.Trees.Length);
				treesData[x].Rotation = RandomValue.RotationY();	

				Instantiate(boxChunk.Trees[treesData[x].Id].Chunk, treesData[x].Position,treesData[x].Rotation, parentPosition);		
			}
			
			return treesData;
		}
	}
}


