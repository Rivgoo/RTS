using UnityEngine;
using System.Collections.Generic;

public class GeneratorIsland : MonoBehaviour 
{
	[Header("Prefab")]
	public ChunkIslandBase[] PrefabIslandsBase;
	public ChunkBlock[] PrefabBlock;
	public GameObject[] PrefabNatureDetails;
	
	[Header("Settings")]
	public bool IsNewIsland = false;
	
	private List<ChunkBlock> _prefabBlock = new List<ChunkBlock>();
	private List<GameObject> _prefabNatureDetails = new List<GameObject>();
	
	private int _isladeBaseID;
	private int[] _prefabBlockID;

	public void Generate()
	{
		CreateFirstChunk();
		CreateSecondChunk();
		CreateDetailsChunk();
	}
	
	private void Start()
	{
		Generate();
	}
	
	private void CreateSecondChunk()
	{
		int[] tempPrefabId = new int[PrefabBlock.Length];
		
		if (IsNewIsland) 
		{
			_prefabBlockID = new int[tempPrefabId.Length];
		}
		
		for (int i = 0; i < PrefabBlock.Length - 1; i++)
		{
			if (IsNewIsland) 
			{
				tempPrefabId[i] = RandomPrefab(PrefabBlock.Length);
				_prefabBlockID[i] = tempPrefabId[i];
			}
			else
			{
				tempPrefabId[i] = _prefabBlockID[i];
			}
		}
		
		int prefabId = 0;
		
		for (int i = 0; i < PrefabIslandsBase[_isladeBaseID].GroundChunkPosition.Length; i++)
		{
			_prefabBlock.Add(Instantiate(PrefabBlock[tempPrefabId[prefabId]], PrefabIslandsBase[_isladeBaseID].GroundChunkPosition[i].position, RandomRotate()));
			
			if (prefabId < PrefabBlock.Length - 1)
			{
				prefabId++;
			}
			else
			{
				prefabId = 0;
			}
		}
		
	}
			
	private void CreateFirstChunk()
	{
		if (IsNewIsland)
		{
			_isladeBaseID = RandomPrefab(PrefabIslandsBase.Length);
		}
		
		Instantiate(PrefabIslandsBase[_isladeBaseID], Vector3.zero, RandomRotate());
		
//		_spawnedChunks.Add(Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]));
//		
//		Chunk newChunk = Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]);
//        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].LeftEnd.position - newChunk.RightEnd.position;
//        newChunk = Instantiate(ObjectsOsnova[Random.Range(0, ObjectsOsnova.Length)]);
//        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].RightEnd.position - newChunk.LeftEnd.position;
	}
	
	private void CreateDetailsChunk()
	{
		int prefabId = 0;
		
		int prefabRandom = RandomPrefab(PrefabNatureDetails.Length);
		
		
		for (int i = 0; i < _prefabBlock.Count; i++)
		{
			for (int x = 0; x < _prefabBlock[i].TreesPosition.Length; x++)
			{
				Instantiate(PrefabNatureDetails[prefabRandom], _prefabBlock[i].TreesPosition[x].position, RandomRotate());
			}
		}
	}
	
	private int RandomPrefab(int endValue)
	{
		return Random.Range(0, endValue);
	}
	
	private Quaternion RandomRotate()
	{
		return Quaternion.Euler(0, Random.Range(-361,360), 0);
	}
	
	private void ClearMap()
	{
		//GameObject[] temp = 
	}
	
	private bool RandomBool()
	{
		return Random.Range(0,10) >= 5;
	}
	
	private void Update()
	{
		if (Input.GetKeyDown("g")) {
			_prefabBlock.Clear();
			Generate();
		}
	}
}
