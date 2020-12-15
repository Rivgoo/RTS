using UnityEngine;

public class GeneratorIsland : MonoBehaviour 
{
	public GeneratorBaseChunk BaseChunk;
	public GeneratorBoxChunk BoxChunk;
	
	public SettingsIslandGenerator Settings;
	
	public void Generate()
	{
		CreateBaseChunk(new Vector3(0,0,0));
		CreateBoxChunks(BaseChunk.Chunks[BaseChunk.IndexBaseChunk].PositionBoxChunk);	
		CreateSmallIsland(BaseChunk.Chunks[BaseChunk.IndexBaseChunk].PositionSmallChunk);
		
		ClearTempObjects();
	}
	
	private void Start()
	{		
		Generate();
		ClearTempObjects();
	}
	
	private void CreateBaseChunk(Vector3 position)
	{
		BaseChunk.Create(position);
		var baseChunkData = BaseChunk.BaseChunkData;
	}
	
	private void CreateBoxChunks(Transform[] positionBox)
	{
		BoxChunk.Create(positionBox);
		var boxChunksData = BoxChunk.BoxsData;
	}
	
	private void CreateSmallIsland(Transform[] positionBox)
	{		
		if (Settings.SmallIslands)
		{
			BoxChunk.Create(positionBox, true);		
			var smallChunkData = BoxChunk.BoxsData;
		}
	}
	
//	private void CreatePrefabResource()
//	{	
//		for (int i = 0; i < Prefab.Boxes.Length; i++) 
//		{
//			Prefab.Boxes[i].TreesPrefab.InitPrefab(Prefab, IslandData);
//			Prefab.Boxes[i].TreesPrefab.Create();
//		}
//	}
	
	private void ClearTempObjects()
	{
		if (Settings.CleanTempItems)
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("TempIslandObjects");
		
			for (int i = 0; i < temp.Length; i++)
			{
				Destroy(temp[i]);
			}
		}	
	}
	
}
[System.Serializable]
public struct SettingsIslandGenerator
{
	public bool CleanTempItems;
	
	public bool SmallIslands;
	public bool TreesOnBoxChunk;
	public bool TreeOnBaseChunk;
	
}

public static class RandomValue
{
	public static int NumberInt(int endValue, int beginVelue = 0)
	{
		return Random.Range(beginVelue, endValue);
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
