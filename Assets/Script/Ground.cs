using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ground : MonoBehaviour {
	public static List<Ground> Map = new List<Ground> ();

	public int type { set; get; }
	public Material mat { set; get; }

	void Start()
	{

	}
}

