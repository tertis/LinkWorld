using System.Collections.Generic;

public class LocalMap
{
	private List<Ground> _map = new List<Ground>();
	private List<int> _selected = new List<int>();
	
	public bool AddGround(Ground ground)
	{
		try
		{
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
			_map[idx].OnReleased();
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
		
		int curX = curPos / Global.MAP_WIDTH;
		int curY = curPos % Global.MAP_WIDTH;
		
		int x, y;
		for (int i = 0; i < GetSize(); ++i)
		{
			x = i / Global.MAP_WIDTH;
			y = i % Global.MAP_WIDTH;
			
			var dis = System.Math.Abs(curX - x) + System.Math.Abs(curY - y);
			
			if (dis <= range)
			{
				_selected.Add(i);
			}
		}
		
		SetSelected();
	}
	
	public void ResetMovable()
	{
		ReleaseSelected();
	}
}