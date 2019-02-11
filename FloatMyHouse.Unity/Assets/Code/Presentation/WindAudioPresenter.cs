using Assets.Code.Model.Balloon;
using UniRx;
using UnityEngine;
using Zenject;

public class WindAudioPresenter : MonoBehaviour
{
	public AudioSource Source;

	[Inject]
	public void Initialize(Balloon balloonModel)
	{
		balloonModel.Events
			.OfType<BalloonEvent, BlowingStartedEvent>()
			.Subscribe(_ => Source.Play());

		balloonModel.Events
			.OfType<BalloonEvent, BlowingEndedEvent>()
			.Subscribe(_ => Source.Stop());
	}
}