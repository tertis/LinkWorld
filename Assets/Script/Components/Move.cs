using System.Collections;

namespace Component
{
	public class Move : Base
	{
		private int curTile = 0;
		public override void Init(object param)
		{
			curTile = (int)param;
		}

		public override void Action ()
		{
			throw new System.NotImplementedException ();
		}
	}
}