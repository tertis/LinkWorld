using UnityEngine;
using System.Collections.Generic;

namespace Actor
{
	public abstract class Base : MonoBehaviour, Part.IOwner {
		protected List<Part.Base> _Components = new List<Part.Base>();

		public Transform _Trans { get { return transform; } }

		public void Update()
		{
			OnUpdate ();
		}

		public abstract void Init (int pos);

		public virtual void OnUpdate()
		{
			foreach (Part.Base com in _Components) {
				com.Action();
			}
		}
	}

	public class Movable : Base, Control.IClickable
	{	
		protected int _pos;
		protected int _range = 2;
		protected bool _isSelected = false;
		public override void Init(int pos)
		{
			_pos = pos;
			Reposition();
		}

		public void OnSelected()
		{
			if (_isSelected)
			{
				_isSelected = false;
				OnReleased(_pos);
				return;
			}
			
			_isSelected = true;
			GetComponent<Renderer> ().material.color = Color.red;
			Global._map.SetMovable(_pos, _range);
		}

		public void OnReleased(int pos)
		{
			if (Global._map.CheckRange(_pos, pos, _range))
			{
				_pos = pos;
				Reposition();
			}
			_isSelected = false;
			
			GetComponent<Renderer> ().material.color = Color.white;
			Global._map.ResetMovable();
		}
		
		public int GetPos()
		{
			return _pos;
		}
		
		private void Reposition()
		{
			_Trans.position = Global._map.GetIdxPos(_pos);
		}
	}
}
