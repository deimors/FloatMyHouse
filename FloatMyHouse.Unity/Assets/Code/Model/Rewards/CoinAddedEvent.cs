namespace Assets.Code.Model.Rewards
{
	public class CoinAddedEvent : RewardsEvent
	{
		public int CoinCount { get; }

		public CoinAddedEvent(int coinCount)
		{
			CoinCount = coinCount;
		}
	}
}