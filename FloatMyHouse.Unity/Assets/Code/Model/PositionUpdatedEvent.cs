using UnityEngine;

public class PositionUpdatedEvent : BalloonEvent
{
	public PositionUpdatedEvent(Vector2 newPosition)
	{
		NewPosition = newPosition;
	}

	public Vector2 NewPosition { get; }
}
