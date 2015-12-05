using UnityEngine;
using System.Collections.Generic;

public class LocalMap
{
	public const int MAP_WIDTH = 5;
	private List<Ground> _map = new List<Ground>();
	private List<int> _selected = new List<int>();
	
	public bool AddGround(Ground ground)
	{
		try
		{
			int idx = _map.Count;
			ground.transform.localPosition = new Vector3(idx % MAP_WIDTH, idx / MAP_WIDTH, 0);
            ground.transform.localScale = new Vector3(Global.TILE_SCALE, Global.TILE_SCALE, Global.TILE_SCALE);
			ground.Init(idx);
			_map.Add(ground);
		}
		catch
		{
			Log.Error("Ground Add Error");
			return false;
		}
		
		return true;
	}
	
	public int GetSize()
	{
		return _map.Count;
	}
	
	private void ReleaseSelected()
	{
		foreach (var idx in _selected)
		{
			_map[idx].OnReleased(idx);
		}
		
		_selected.Clear();
	}
	
	private void SetSelected()
	{
		foreach (var idx in _selected)
		{
			_map[idx].OnSelected();
		}
	}
	
	public void SetMovable(int curPos, int range)
	{
		ReleaseSelected();
		
		for (int i = 0; i < GetSize(); ++i)
		{
			if (CheckRange(curPos, i, range))
			{
				_selected.Add(i);
			}
		}
		
		SetSelected();
	}
	
	public bool CheckRange(int pos, int checkPos, int range)
	{
		int curX = pos / MAP_WIDTH;
		int curY = pos % MAP_WIDTH;
		var x = checkPos / MAP_WIDTH;
		var y = checkPos % MAP_WIDTH;
		var dis = System.Math.Abs(curX - x) + System.Math.Abs(curY - y);
		return dis <= range;
	}
	
	public void ResetMovable()
	{
		ReleaseSelected();
	}
	
	public Vector3 GetIdxPos(int idx)
	{
		return _map[idx].transform.position;
	}
}