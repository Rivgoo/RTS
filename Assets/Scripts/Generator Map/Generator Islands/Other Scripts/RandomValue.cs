using UnityEngine;

public static class RandomValue
{
	public static int Number(int endValue, int beginVelue = 0)
	{
		return Random.Range(beginVelue, endValue);
	}
	
	public static float Number(float endValue, float beginVelue = 0)
	{
		return Random.Range(beginVelue, endValue);
	}
	
	public static Quaternion RotationY()
	{
		return Quaternion.Euler(0, Random.Range(-361,360), 0);
	}
}
