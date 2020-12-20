using UnityEngine;
using UnityEditor;
using Generators;

[CustomEditor(typeof(GeneratorIsland))]
public class EditorGeneratorIsland : Editor 
{
	public override void OnInspectorGUI()
	{	
		DrawDefaultInspector();
		var generator = (GeneratorIsland)target;
		
		if (GUILayout.Button("Generate"))
		{
			if (!generator.IsPlayGame) 
			{
				generator.Settings.CleanTempItems = false;
			}
			generator.Generate();
		}	
	}
}
