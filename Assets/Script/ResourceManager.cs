using UnityEngine;
using System.Collections.ObjectModel;

namespace Manager
{
	public static class Action
	{
		public static T[] LoadAll<T>(string path) where T : Object
		{
			Object[] sources = Resources.LoadAll(path);
			T[] data = new T[sources.Length];
			for (int i =0; i < sources.Length; ++i) 
			{
				data[i] = sources[i] as T;
			}
			return data;
		}

		public static T Load<T>(string filePath) where T : Object
		{
			return Resources.Load (filePath) as T;
		}
	}

	public class Resource
	{
		public static ReadOnlyCollection<Texture2D> Ground;
		public static ReadOnlyCollection<string> GroundName;
		public static ReadOnlyCollection<int> Map;

		public static void Create()
		{
			Log.Trace ("Resource Create Start");
			Ground = new ReadOnlyCollection<Texture2D> (Action.LoadAll<Texture2D>("Texture/Ground"));
			GroundName = new ReadOnlyCollection<string> (Action.Load<TextAsset> ("Data/GroundName").text.Replace("\n", "").Split(','));
			Map = new ReadOnlyCollection<int>( System.Array.ConvertAll <string,int>(Action.Load<TextAsset> ("Data/Map").text.Replace("\n", "").Split(','), int.Parse));

			Log.Trace ("Resource Create Done.");
		}
	}
}