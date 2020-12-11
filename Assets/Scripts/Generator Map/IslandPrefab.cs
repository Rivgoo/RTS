using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IslandPrefab
{
	public ChunkIslandBase[] IslandsBase;
	public ChunkBlock[] Boxes;
	public ChunkDefoult[] Details;
	//public GameObject[] Trees;
	public GameObject[] Rocks;
	public GameObject[] Gresses;
	
	[HideInInspector]
	public List<ChunkBlock> ListBoxes;
}

