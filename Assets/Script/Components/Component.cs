using UnityEngine;

namespace Part
{
	public interface IOwner
	{
		Transform _Trans { get; }
	}

	public abstract class Base 
	{
		protected IOwner _Owner;
		public virtual void Init (IOwner owner)
		{
			_Owner = owner;
		}
		public abstract void Action ();
	}
}