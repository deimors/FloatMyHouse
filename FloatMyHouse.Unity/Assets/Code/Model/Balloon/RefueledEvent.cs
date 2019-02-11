namespace Assets.Code.Model.Balloon
{
	public class RefueledEvent : BalloonEvent
	{
		public float Amount { get; }
		public float NewFuelAmount { get; }

		public RefueledEvent(float amount, float newFuelAmount)
		{
			Amount = amount;
			NewFuelAmount = newFuelAmount;
		}
	}
}