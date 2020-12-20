using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class Console : MonoBehaviour 
{ 
	public Text MainText;
	public ConsoleText texts; 
	public int MaxHeightText;
	
	private string _filePatch; 
	private int cuurentPositionLine;
	
	public void Start()
	{		

		_filePatch = Path.Combine(Application.dataPath + "/StreamingAssets","Text Console/FirstPlayGame.json");
		texts.text = JsonUtility.FromJson<JsonText>(File.ReadAllText(_filePatch)).Text;

		WriteConsole(texts); 

		
	}
	
	[System.Serializable]
	private struct JsonText
	{
		public string[] Text;
	}
	
	public void WriteConsole(ConsoleText text)
	{
		StartCoroutine(Write(text));
		
	}
	
	IEnumerator Write(ConsoleText text)
	{		
		for (int i = 0; i < text.text.Length; i++)
		{		
			WaitSecond[] Line = new WaitSecond[text.text.Length];
			WaitSecond[] Letter = new WaitSecond[text.text.Length];
			
			for (int y = 0; y < text.WaitSecondLines.Length; y++)
			{
				Line[y] = text.WaitSecondLines[y];
			}
			
			for (int y = 0; y < text.WaitSecondLines.Length; y++)
			{
				Letter[y] = text.WaitSecondLetters[y];
			}
			
			for (int x = 0; x <  text.text[i].Length; x++)
			{
				MainText.text += text.text[i][x];
				
				yield return new WaitForSeconds(Random.Range(Letter[i].Begin,Letter[i].End));
			}
			
			if (i >= MaxHeightText)
			{
				MainText.text = MainText.text.Remove(0, text.text[0 + cuurentPositionLine].Length + 1);
				cuurentPositionLine++;
			}
			
			yield return new WaitForSeconds(Random.Range(Line[i].Begin,Line[i].End));
			MainText.text += "\n";
		}
		yield return null;
	}
}

[System.Serializable]
public struct ConsoleText
{
	public string[] text;
	public WaitSecond[] WaitSecondLines;
	public WaitSecond[] WaitSecondLetters;
}
[System.Serializable]
public struct WaitSecond
{
	public float Begin;
	public float End;
}