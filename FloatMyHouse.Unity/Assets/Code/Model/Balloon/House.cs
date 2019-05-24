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

	public class BagDetachedEvent : HouseEvent
	{
		public BagIdentifier BagId { get; }

		public BagDetachedEvent([NotNull] BagIdentifier bagId)
		{
			BagId = bagId ?? throw new ArgumentNullException(nameof(bagId));
		}
	}

	public class House
	{
		private readonly IDictionary<BalloonIdentifier, float> _balloonHeights = new Dictionary<BalloonIdentifier, float>();
		private readonly IDictionary<BagIdentifier, float> _bags = new Dictionary<BagIdentifier, float>();

		private readonly ISubject<HouseEvent> _events = new Subject<HouseEvent>();

		public IObservable<HouseEvent> Events => _events;

		public void Attach(BalloonIdentifier balloonId, float height)
		{
			_balloonHeights[balloonId] = height;
		}
		
		public void DetachBalloon()
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

		public void Attach(BagIdentifier bagId, float x)
		{
			_bags[bagId] = x;
		}

		public void DetachBag()
		{
			if (!_bags.Any())
				return;

			var furthestBagId = _bags
				.OrderByDescending(pair => Math.Abs(pair.Value))
				.Select(pair => pair.Key)
				.First();

			_bags.Remove(furthestBagId);

			_events.OnNext(new BagDetachedEvent(furthestBagId));
		}
	}
	
	public class BagIdentifier
	{
		public override string ToString()
			=> GetHashCode().ToString("x");
	}

	public class BalloonIdentifier
	{
		public override string ToString()
			=> GetHashCode().ToString("x");
	}
}