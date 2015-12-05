using UnityEngine;
using System.Text;

public static class Log
{
	private static StringBuilder sb = new StringBuilder();
	public static void Error(string msg, params object[] arg)
	{
		sb.Length = 0;
		Debug.LogError(sb.AppendFormat(msg, arg));
	}
	
	public static void Warning(string msg, params object[] arg)
	{
		sb.Length = 0;
		Debug.LogWarning(sb.AppendFormat(msg, arg));
	}
	
	public static void Trace(string msg, params object[] arg)
	{
		sb.Length = 0;
		Debug.Log(sb.AppendFormat(msg, arg));
	}
}