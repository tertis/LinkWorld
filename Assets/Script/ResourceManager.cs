using UnityEngine;
using System.Collections.ObjectModel;

namespace Resource
{
	public static class Data
	{
        private const string PATH_GROUND = "Data/GroundName";
        private const string PATH_MAP = "Data/Map";
		public static ReadOnlyCollection<string> groundName;
		public static ReadOnlyCollection<int> mapNum;

		public static bool Create()
		{
			Log.Trace ("Resource Create Start");
			groundName = new ReadOnlyCollection<string> (Load<TextAsset> (PATH_GROUND).text.Replace("\n", "").Split(','));
			mapNum = new ReadOnlyCollection<int>( System.Array.ConvertAll <string,int>(Load<TextAsset> (PATH_MAP).text.Replace("\n", "").Split(','), int.Parse));

            if (groundName.Count == 0 || mapNum.Count == 0)
            {
                return false;
            }

			Log.Trace ("Resource Create Done.");
            return true;
		}
        
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
}