using UnityEngine;
using System.Collections.Generic;

public class TreePrefabs : CreatePrefabs
{
//	public override void Create()
//	{
//		if (PrefabResource.Length < 2) 
//		{
//			IsRepeatPrefab = true;
//		}
//		
//		for (int i = 0; i < Prefab.ListBoxes.Count; i++)
//		{
//			int indexLastTree = -1;
//			int numberTrees = GetRandomNumber();
//			
//			Vector3 [,]position = GetRandomPosition(Prefab.ListBoxes[i].TreesPosition, numberTrees);
//			 
//			for (int d = 0; d < Prefab.ListBoxes[i].TreesPosition.Length; d++)
//			{
//				for (int y = 0; y < numberTrees; y++)
//				{
//					int indexCurrentTree = RandomValue.NumberInt(PrefabResource.Length);
//						
//					if (!IsRepeatPrefab && indexCurrentTree == indexLastTree) 
//					{
//						y--;
//					}
//					else
//					{	
//						indexLastTree = indexCurrentTree;
//						int randomIndexTree = RandomValue.NumberInt(indexCurrentTree);
//							
//						IslandData.PrefabTreesID.Add(randomIndexTree);
//						IslandData.PrefabTreesTransform.Add(Instantiate(PrefabResource[randomIndexTree], position[d,y], RandomValue.RotationY()).transform);
//						
//					}
//				}
//			}
//		}
//	}
}
