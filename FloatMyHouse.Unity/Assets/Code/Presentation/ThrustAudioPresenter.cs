using System;
using UniRx;
using UnityEngine;
using Zenject;

public class ThrustAudioPresenter : MonoBehaviour
{
	public AudioSource Source;

	[Inject]
	public void Initialize(Balloon balloonModel)
	{
		balloonModel.Events
			.OfType<BalloonEvent, LiftStartedEvent>()
			.Subscribe(_ => Source.Play());

		balloonModel.Events
			.OfType<BalloonEvent, LiftEndedEvent>()
			.Subscribe(_ => Source.Stop());
	}
}
