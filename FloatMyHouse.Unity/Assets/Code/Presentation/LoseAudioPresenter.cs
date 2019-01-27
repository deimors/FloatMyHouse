using UniRx;
using UnityEngine;
using Zenject;

public class LoseAudioPresenter : MonoBehaviour
{
	public AudioSource Source;

	[Inject]
	public void Initialize(Game gameModel)
	{
		gameModel.Events
			.OfType<GameEvent, GameLostEvent>()
			.Subscribe(_ => Source.Play());
	}
}