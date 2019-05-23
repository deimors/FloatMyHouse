using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UniRx;

namespace Assets.Code.Model.Balloon
{
	public abstract class HouseEvent { }

	public class BalloonDetachedEvent : HouseEvent
	{
		public BalloonIdentifier BalloonId { get; }

		public BalloonDetachedEvent([NotNull] BalloonIdentifier balloonId)
		{
			BalloonId = balloonId ?? throw new ArgumentNullException(nameof(balloonId));
		}
	}

	public class House
	{
		private readonly IDictionary<BalloonIdentifier, float> _balloonHeights = new Dictionary<BalloonIdentifier, float>();
		private readonly ISubject<HouseEvent> _events = new Subject<HouseEvent>();

		public IObservable<HouseEvent> Events => _events;

		public void Attach(BalloonIdentifier balloonId, float height)
		{
			_balloonHeights[balloonId] = height;
		}

		public void UpdateHeight(BalloonIdentifier balloonId, float height)
		{
			if (_balloonHeights.ContainsKey(balloonId))
				_balloonHeights[balloonId] = height;
		}

		public void DetachHighest()
		{
			if (!_balloonHeights.Any())
				return;

			var highestBalloonId = _balloonHeights
				.OrderByDescending(pair => pair.Value)
				.Select(pair => pair.Key)
				.First();

			_balloonHeights.Remove(highestBalloonId);

			_events.OnNext(new BalloonDetachedEvent(highestBalloonId));
		}
	}

	public class BalloonIdentifier
	{
		public override string ToString()
			=> GetHashCode().ToString("X");
	}
}