using UnityEngine;
using System.Collections.Generic;

public class GeneratorIsland : MonoBehaviour 
{
	[Header("Prefab")]
	public IslandPrefab Prefab;
	
	[Header("Settings")]
	public SaveIslandData IslandData;
	
	public CreatePrefabs[] PrefabResource;
	
	public void Generate()
	{
		CreateFirstChunk();
		CreateSecondChunk();
		CreatePrefabResource();
	}
	
	private void Start()
	{		
		Generate();
		ClearTempObjects();
	}
	
	private void CreateSecondChunk()
	{	
		for (int i = 0; i < Prefab.IslandsBase[IslandData.IslandBaseID].GroundChunkPosition.Length; i++)
		{
			IslandData.PrefabBoxesID.Add(RandomValue.NumberInt(Prefab.Boxes.Length));
			Prefab.ListBoxes.Add(Instantiate(Prefab.Boxes[IslandData.PrefabBoxesID[i]], Prefab.IslandsBase[IslandData.IslandBaseID].GroundChunkPosition[i].position, RandomValue.RotationY()));
		}
	}
			
	private void CreateFirstChunk()
	{
		IslandData.IslandBaseID = RandomValue.NumberInt(Prefab.IslandsBase.Length);
		
		IslandData.IslandBaseTransform = Instantiate(Prefab.IslandsBase[IslandData.IslandBaseID], transform.position,RandomValue.RotationY()).transform;
		
//		_spawnedChunks.Add(Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]));
//		
//		Chunk newChunk = Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]);
//        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].LeftEnd.position - newChunk.RightEnd.position;
//        newChunk = Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]);
//        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].RightEnd.position - newChunk.LeftEnd.position;
	}
	
	private void CreatePrefabResource()
	{
		
		for (int i = 0; i < PrefabResource.Length; i++) 
		{
			PrefabResource[i].InitPrefab(Prefab, IslandData);
			PrefabResource[i].Create();
		}
	}
	
	private void ClearTempObjects()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag("TempObjectForCreateIsland");
		
		for (int i = 0; i < temp.Length; i++)
		{
			Destroy(temp[i]);
		}
	}
	
	private void Update()
	{
		if (Input.GetKeyDown("g")) {
			Prefab.ListBoxes.Clear();
			IslandData.PrefabBoxesID.Clear();
			Generate();
		}
	}
}

public static class RandomValue
{
	public static int NumberInt(int endValue)
	{
		return Random.Range(0, endValue);
	}
	
	public static Quaternion RotationY()
	{
		return Quaternion.Euler(0, Random.Range(-361,360), 0);
	}
	
//	public static bool RandomBool()
//	{
//		return Random.Range(0,10) >= 5;
//	}
}
