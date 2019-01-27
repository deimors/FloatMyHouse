public class CoinAddedEvent : RewardsEvent
{
	public int CoinCount { get; }

	public CoinAddedEvent(int coinCount)
	{
		CoinCount = coinCount;
	}
}