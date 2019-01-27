using System;
using UniRx;

public class Rewards
{
	private ISubject<RewardsEvent> _events = new Subject<RewardsEvent>();
	public IObservable<RewardsEvent> Events => _events;

	private int _coinCount;

	public void AddCoin()
	{
		_coinCount++;
		_events.OnNext(new CoinAddedEvent(_coinCount));
	}
}
