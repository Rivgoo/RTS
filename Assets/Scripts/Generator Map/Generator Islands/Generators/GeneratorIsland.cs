using UnityEngine;

namespace Generators
{
	public class GeneratorIsland : MonoBehaviour 
	{
		[SerializeField] 
		private GeneratorBaseChunk _baseChunk;
		[SerializeField]
		private GeneratorBoxChunk _boxChunk; 
		[SerializeField]
		private GeneratorTrees _treeItem;
		
		[HideInInspector]
		public bool IsPlayGame = false;
		
		public SettingsIslandGenerator Settings;
	
		public void Generate()
		{
			CreateBaseChunk(this.gameObject.transform);
	
			CreateBoxChunks(_baseChunk.Chunks[_baseChunk.BaseChunkData.id].PositionBoxChunk,this.gameObject.transform);
		
			CreateSmallIsland(_baseChunk.Chunks[_baseChunk.BaseChunkData.id].PositionSmallChunk, this.gameObject.transform);
			
			CreateTree(_boxChunk);
			//CreateTree(_baseChunk);
	
			ClearTempObjects();
		}
	
		private void Start()
		{	
			IsPlayGame = true;
			
			if (Settings.CreateOnStart)
			{
				Generate();
				ClearTempObjects();
			}
		}
		
		private void CreateBaseChunk(Transform baseObject)
		{
			_baseChunk.Create(baseObject);
		}
		
		private void CreateBoxChunks(Transform[] positionBox, Transform  baseObject)
		{
			_boxChunk.Create(positionBox, baseObject);
		}
		
		private void CreateSmallIsland(Transform[] positionSmallIsland, Transform  baseObject)
		{		
			if (Settings.SmallIslands)
			{
				_boxChunk.Create(positionSmallIsland, baseObject, true);		
			}
		}
		
		private void CreateTree(GeneratorBaseChunk baseChunk)
		{
			_treeItem.Create(baseChunk);
			var treeData = _treeItem.TreesData; 
		}
		
		private void CreateTree(GeneratorBoxChunk boxChunk)
		{
			_treeItem.Create(boxChunk);
			var treeData = _treeItem.TreesData; 
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
}
