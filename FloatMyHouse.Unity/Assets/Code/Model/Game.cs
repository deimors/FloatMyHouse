using System;
using UniRx;

public class Game
{
	private ISubject<GameEvent> _events = new Subject<GameEvent>();
	public IObservable<GameEvent> Events => _events;

	public void Win()
	{
		_events.OnNext(new GameWonEvent());
	}
}
