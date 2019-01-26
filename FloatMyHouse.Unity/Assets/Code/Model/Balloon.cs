using System;
using UniRx;

public class Balloon
{
	private readonly ISubject<BalloonEvent> _events = new Subject<BalloonEvent>();
	public IObservable<BalloonEvent> Events => _events;

	private bool _addingLift;

	public Balloon(IObservable<TimeTickEvent> time)
	{
		time.Where(_ => _addingLift)
			.Subscribe(_ => _events.OnNext(new LiftAddedEvent()));
	}

	public void StartLift()
	{
		_addingLift = true;
	}

	public void EndLift()
	{
		_addingLift = false;
	}
}
