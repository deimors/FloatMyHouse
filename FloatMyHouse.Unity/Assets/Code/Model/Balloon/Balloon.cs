using System;
using UniRx;
using UnityEngine;

namespace Assets.Code.Model.Balloon
{
	public class Balloon
	{
		private const float MaxFuelLevel = 100;
		private const float InitialFuelLevel = 100;
		private const float FuelConsumedPerSecond = 10;
		private const float RefuelPerSecond = 50;
		private const float ForcePerSecond = 600;

		private readonly ISubject<BalloonEvent> _events = new Subject<BalloonEvent>();
		public IObservable<BalloonEvent> Events => _events;

		private bool _addingLift;
		private bool _refueling;
		private int _blowing;

		private float _currentFuelLevel;

		public Balloon(IObservable<TimeTickEvent> time)
		{
			time.Take(1)
				.Subscribe(_ => Initialize());

			time.Where(_ => _addingLift)
				.Subscribe(e => AddLift(e));

			time.Where(_ => _refueling)
				.Subscribe(e => Refuel(e));
		}
	
		public void StartLift()
		{
			_addingLift = true;

			_events.OnNext(new LiftStartedEvent());
		}

		public void EndLift()
		{
			if (_addingLift)
			{
				_addingLift = false;

				_events.OnNext(new LiftEndedEvent());
			}
		}

		public void UpdatePosition(Vector2 position)
		{
			_events.OnNext(new PositionUpdatedEvent(position));
		}

		public void StartRefueling()
		{
			_refueling = true;
		}

		public void EndRefueling()
		{
			_refueling = false;
		}

		public void StartBlowing()
		{
			_blowing++;

			if (_blowing == 1)
				_events.OnNext(new BlowingStartedEvent());
		}

		public void EndBlowing()
		{
			_blowing--;

			if (_blowing == 0)
				_events.OnNext(new BlowingEndedEvent());
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
				var fuelConsumed = Math.Min(FuelConsumedPerSecond * tickEvent.DeltaTime, _currentFuelLevel);

				_currentFuelLevel -= fuelConsumed;

				var liftForce = ForcePerSecond * tickEvent.DeltaTime;

				_events.OnNext(new LiftAddedEvent(liftForce));
				_events.OnNext(new FuelConsumedEvent(fuelConsumed, _currentFuelLevel));
			}
			else
			{
				EndLift();
			}
		}

		private void Refuel(TimeTickEvent tickEvent)
		{
			if (_currentFuelLevel < MaxFuelLevel)
			{
				var refuelAmount = Math.Min(RefuelPerSecond * tickEvent.DeltaTime, MaxFuelLevel - _currentFuelLevel);

				_currentFuelLevel += refuelAmount;

				_events.OnNext(new RefueledEvent(refuelAmount, _currentFuelLevel));
			}
		}
	}
}