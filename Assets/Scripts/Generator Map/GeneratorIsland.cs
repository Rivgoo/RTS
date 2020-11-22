using UnityEngine;
using System.Collections.Generic;

public class GeneratorIsland : MonoBehaviour 
{
	[Header("Prefab")]
	public IslandPrefab Prefab;
	
	[Header("Settings")]
	public SaveIslandData IslandData;

	public void Generate()
	{
		CreateFirstChunk();
		CreateSecondChunk();
		CreateDetailsChunk();
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
			IslandData.PrefabBoxesID.Add(RandomInt(Prefab.Boxes.Length));
			Prefab.ListBoxes.Add(Instantiate(Prefab.Boxes[IslandData.PrefabBoxesID[i]], Prefab.IslandsBase[IslandData.IslandBaseID].GroundChunkPosition[i].position, RandomRotate()));
		}
	}
			
	private void CreateFirstChunk()
	{
		IslandData.IslandBaseID = RandomInt(Prefab.IslandsBase.Length);
		
		IslandData.IslandBaseTransform = Instantiate(Prefab.IslandsBase[IslandData.IslandBaseID], transform.position, RandomRotate()).transform;
		
//		_spawnedChunks.Add(Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]));
//		
//		Chunk newChunk = Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]);
//        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].LeftEnd.position - newChunk.RightEnd.position;
//        newChunk = Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]);
//        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].RightEnd.position - newChunk.LeftEnd.position;
	}
	
	private void CreateDetailsChunk()
	{			
		for (int i = 0; i < Prefab.ListBoxes.Count; i++)
		{
			for (int x = 0; x < Prefab.ListBoxes[i].TreesPosition.Length; x++)
			{
				IslandData.PrefabTreesID.Add(RandomInt(Prefab.Trees.Length));
				Vector3 randomPosition = new Vector3(Prefab.ListBoxes[i].TreesPosition[x].position.x, Prefab.ListBoxes[i].TreesPosition[x].position.y, Prefab.ListBoxes[i].TreesPosition[x].position.z);
				IslandData.PrefabTreesTransform.Add(Instantiate(Prefab.Trees[IslandData.PrefabTreesID[x]], Prefab.ListBoxes[i].TreesPosition[x].position, RandomRotate()).transform);
			}
		}
		
		
	}
	
	private int RandomInt(int endValue)
	{
		return Random.Range(0, endValue);
	}
	
	private Quaternion RandomRotate()
	{
		return Quaternion.Euler(0, Random.Range(-361,360), 0);
	}
	
	private bool RandomBool()
	{
		return Random.Range(0,10) >= 5;
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

