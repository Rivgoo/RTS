using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RestrictionTreePlacement))]
public class RestrictionTreePlacementEditor : Editor
{
	public override void OnInspectorGUI()
	{	
		var tree = (RestrictionTreePlacement)target;
		
		if(DrawDefaultInspector())
		{			
			tree.VisualColider();		
		}
		
		if (GUILayout.Button("Update"))
		{
			tree.VisualColider();
		}
	}
}
