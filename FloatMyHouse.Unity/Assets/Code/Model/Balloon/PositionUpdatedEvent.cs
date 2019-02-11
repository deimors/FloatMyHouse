using UnityEngine;

namespace Assets.Code.Model.Balloon
{
	public class PositionUpdatedEvent : BalloonEvent
	{
		public PositionUpdatedEvent(Vector2 newPosition)
		{
			NewPosition = newPosition;
		}

		public Vector2 NewPosition { get; }
	}
}
