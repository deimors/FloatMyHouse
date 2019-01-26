using UnityEngine;

public class GoalPositionInitializedEvent : GameEvent
{
	public GoalPositionInitializedEvent(Vector2 position)
	{
		Position = position;
	}

	public Vector2 Position { get; }
}
