namespace Assets.Code.Model.Balloon
{
	public class InitializedEvent : BalloonEvent
	{
		public float MaxFuelLevel { get; }
		public float CurrentFuelLevel { get; }

		public InitializedEvent(float maxFuelLevel, float currentFuelLevel)
		{
			MaxFuelLevel = maxFuelLevel;
			CurrentFuelLevel = currentFuelLevel;
		}
	}
}
