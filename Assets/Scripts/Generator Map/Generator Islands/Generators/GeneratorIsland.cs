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
		private GeneratorBoxChunk _smallIslandChunk; 
		
		
		[HideInInspector]
		public bool IsPlayGame = false;
		
		public SettingsIslandGenerator Settings;
	
		public void Generate()
		{
			CreateBaseChunk(this.gameObject.transform);
	
			CreateBoxChunks(_baseChunk.Chunks[_baseChunk.BaseChunkData.Id].PositionBoxChunk,this.gameObject.transform);
			CreateSmallIsland(_baseChunk.Chunks[_baseChunk.BaseChunkData.Id].PositionSmallChunk, this.gameObject.transform);
					
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
				_smallIslandChunk.Create(positionSmallIsland, baseObject);		
			}
		}
		 
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
