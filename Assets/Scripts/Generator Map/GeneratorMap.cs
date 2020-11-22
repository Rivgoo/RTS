using UnityEngine;
using System.Collections.Generic;

public class GeneratorMap : MonoBehaviour 
{
	[Header("Prefab")]
	public ChunkIslandBase[] PrefabIslandsBase;
	public ChunkGround[] PrefabGround;
	public GameObject[] PrefabChunkDetailsNature;
	
	[Header("Settings")]
	public bool IsNewIslad = false;
	
	private List<ChunkDefoult> _prefabGround = new List<ChunkDefoult>();
	
	private int _isladeBaseID;
	private int[] _prefabGroundId;

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
		int[] tempPrefabId = new int[PrefabGround.Length];
		
		if (IsNewIslad) 
		{
			_prefabGroundId = new int[tempPrefabId.Length];
		}
		
		for (int i = 0; i < PrefabGround.Length - 1; i++)
		{
			if (IsNewIslad) 
			{
				tempPrefabId[i] = RandomPrefab(PrefabGround.Length);
				_prefabGroundId[i] = tempPrefabId[i];
			}
			else
			{
				tempPrefabId[i] = _prefabGroundId[i];
			}
		}
		
		int prefabId = 0;
		
		for (int i = 0; i < PrefabIslandsBase[_isladeBaseID].GroundChunkPosition.Length; i++)
		{
			_prefabGround.Add(Instantiate(PrefabGround[tempPrefabId[prefabId]], PrefabIslandsBase[_isladeBaseID].GroundChunkPosition[i].position, RandomRotate()));
			
			if (prefabId < PrefabGround.Length - 1)
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
		if (IsNewIslad)
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
		
		int prefabRandom = RandomPrefab(PrefabChunkDetailsNature.Length);
		
		
		for (int i = 0; i < _prefabGround.Count; i++)
		{
			for (int x = 0; x < _prefabGround[i].DetailsPosition.Length; x++)
			{
				Instantiate(PrefabChunkDetailsNature[prefabRandom], _prefabGround[i].DetailsPosition[x].position, RandomRotate());
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
	
	private bool RandomBool()
	{
		return Random.Range(0,10) >= 5;
	}
	
	private void Update()
	{
		if (Input.GetKeyDown("g")) {
			_prefabGround.Clear();
			Generate();
		}
	}
}
