using Assets.Code.Model.Game;
using UniRx;
using UnityEngine;
using Zenject;

public class WinAudioPresenter : MonoBehaviour
{
	public AudioSource Source;

	[Inject]
	public void Initialize(Game gameModel)
	{
		gameModel.Events
			.OfType<GameEvent, GameWonEvent>()
			.Subscribe(_ => Source.Play());
	}
}
