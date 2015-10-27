using UnityEngine;
using System.Collections.Generic;

namespace Actor
{
	public abstract class Base : MonoBehaviour, Component.IOwner {
		protected List<Component.Base> _Components = new List<Component.Base>();

		public Transform _Trans { get { return transform; } }

		public void Start()
		{
			Init ();
		}

		public void Update()
		{
			OnUpdate ();
		}

		public abstract void Init ();

		public virtual void OnUpdate()
		{
			foreach (Component.Base com in _Components) {
				com.Action();
			}
		}
	}

	public class Movable : Base, Control.IClickable
	{
		public override void Init()
		{

		}

		public void OnSelected()
		{
			GetComponent<Renderer> ().material.color = Color.red;
		}

		public void OnReleased()
		{
			GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}
