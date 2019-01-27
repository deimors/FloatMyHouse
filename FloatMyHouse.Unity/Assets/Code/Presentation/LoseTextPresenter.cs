using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoseTextPresenter : MonoBehaviour
{
	public Text LoseText;

	[Inject]
	public void Initialize(Game gameModel)
	{
		gameModel.Events.OfType<GameEvent, GameLostEvent>().Subscribe(_ => ShowGameLost());

		gameModel.Events.OfType<GameEvent, GameLostEvent>().Delay(TimeSpan.FromSeconds(3)).Subscribe(_ => gameModel.RestartLevel());
	}

	private void ShowGameLost()
	{
		LoseText.enabled = true;
	}
}
