public class FuelConsumedEvent : BalloonEvent
{
	public float Amount { get; }
	public float NewFuelLevel { get; }

	public FuelConsumedEvent(float amount, float newFuelLevel)
	{
		Amount = amount;
		NewFuelLevel = newFuelLevel;
	}	
}