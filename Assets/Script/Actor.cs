using UnityEngine;
using System.Collections.Generic;

namespace Actor
{
	public abstract class Base : MonoBehaviour, Component.IOwner {
		protected List<Component.Base> _Components = new List<Component.Base>();

		public Transform _Trans { get { return transform; } }

		public void Update()
		{
			OnUpdate ();
		}

		public abstract void Init (int pos);

		public virtual void OnUpdate()
		{
			foreach (Component.Base com in _Components) {
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
		}

		public void OnSelected()
		{
			if (_isSelected)
			{
				_isSelected = false;
				OnReleased();
				return;
			}
			
			_isSelected = true;
			GetComponent<Renderer> ().material.color = Color.red;
			Global._map.SetMovable(_pos, _range);
		}

		public void OnReleased()
		{
			GetComponent<Renderer> ().material.color = Color.white;
			Global._map.ResetMovable();
		}
	}
}
