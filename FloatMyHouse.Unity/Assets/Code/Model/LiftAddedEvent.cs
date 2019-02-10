public class LiftAddedEvent : BalloonEvent
{
	public float Force { get; }

	public LiftAddedEvent(float force)
	{
		Force = force;
	}
}