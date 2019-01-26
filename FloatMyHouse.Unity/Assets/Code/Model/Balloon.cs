using System;
using UniRx;
using UnityEngine;

public class Balloon
{
	private const float MaxFuelLevel = 100;
	private const float InitialFuelLevel = 100;
	private const float FuelConsumedPerSecond = 10;

	private readonly ISubject<BalloonEvent> _events = new Subject<BalloonEvent>();
	public IObservable<BalloonEvent> Events => _events;

	private bool _addingLift;

	private float _currentFuelLevel;

	public Balloon(IObservable<TimeTickEvent> time)
	{
		time.Where(_ => _addingLift)
			.Subscribe(e => AddLift(e));

		time.Take(1)
			.Subscribe(_ => Initialize());
	}
	
	public void StartLift()
	{
		_addingLift = true;
	}

	public void EndLift()
	{
		_addingLift = false;
	}

	public void UpdatePosition(Vector2 position)
	{
		_events.OnNext(new PositionUpdatedEvent(position));
	}

	private void Initialize()
	{
		_currentFuelLevel = InitialFuelLevel;
		_events.OnNext(new InitializedEvent(MaxFuelLevel, _currentFuelLevel));
	}

	private void AddLift(TimeTickEvent tickEvent)
	{
		if (_currentFuelLevel > 0)
		{
			var fuelConsumed = FuelConsumedPerSecond * tickEvent.DeltaTime;

			_currentFuelLevel = Math.Max(0f, _currentFuelLevel - fuelConsumed);

			_events.OnNext(new LiftAddedEvent());
			_events.OnNext(new FuelConsumedEvent(fuelConsumed, _currentFuelLevel));
		}
	}
}