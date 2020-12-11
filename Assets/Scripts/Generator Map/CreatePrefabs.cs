using UnityEngine;
using System.Collections.Generic;

public abstract class CreatePrefabs : MonoBehaviour
{	
	public float MaxDistanceRandom;
	public float MinDistanceRandom;
	
	public int MaxNumberPrefabs;
	public int MinNumberPrefabs;
	
	public bool IsRepeatPrefab = false;
	
	public GameObject[] PrefabResource;
	
	protected IslandPrefab Prefab;
	protected SaveIslandData IslandData;
	
	public void InitPrefab(IslandPrefab prefab, SaveIslandData islandData)
	{
		Prefab = prefab;
		IslandData = islandData;
	}
	
	public abstract void Create();
	
	protected Vector3[,] GetRandomPosition(ChunkBlock prefab, GameObject[] target, int number)
	{
		var position = new Vector3[target.Length, number + 1];
		
		for (int x = 0; x < target.Length; x++) 
		{				
			Vector3 targetTranform = target[x].GetComponent<Transform>().position;
			position[x, 0] = new Vector3(targetTranform.x, targetTranform.y, targetTranform.z);
				
			for (int i = 1; i < number; i++)
			{
				print("P" + targetTranform);
				var tempPosition = new Vector3(targetTranform.x + Random.Range( MinDistanceRandom, MaxDistanceRandom) * GetPositiveOrNegativeNumber(), targetTranform.y, targetTranform.z + Random.Range(MinDistanceRandom, MaxDistanceRandom) * GetPositiveOrNegativeNumber());
				print("V" + tempPosition);
				if (target[x].GetComponent<RestrictionTreePlacement>().Distanse(tempPosition)) 
				{
					position[x,i] = tempPosition;
				}
				else
				{
					i--;
				}
//				Vector3 down = transform.TransformDirection(Vector3.down) * 500;
//				Ray ray = new Ray(tempPosition, down);
//        		RaycastHit hit;
// 
//	        	if (Physics.Raycast(ray, out hit, 100f))
//	        	{
//	            	if (hit.collider == prefabCollider)
//	            	{
//	                	position[x,i] = tempPosition;
//	            	}
//	            	else
//	            	{
//	            		i--;
//	            	}
//	        	}
				//position[x,i] = tempPosition;
			}
		}
		
		return position;
	}
	
	protected int GetPositiveOrNegativeNumber()
	{
		return Random.Range(-10, 11) > 0? 1: -1;
	}
	
	protected int GetRandomNumber()
	{
		return Random.Range(MinNumberPrefabs, MaxNumberPrefabs + 1);
	}
}