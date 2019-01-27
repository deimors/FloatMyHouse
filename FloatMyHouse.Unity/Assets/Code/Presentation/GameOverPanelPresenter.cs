using UniRx;
using UnityEngine;
using Zenject;

public class GameOverPanelPresenter : MonoBehaviour
{
	public GameObject LosePanel;

	[Inject]
	public void Initialize(Game gameModel)
	{
		gameModel.Events.OfType<GameEvent, GameLostEvent>().Subscribe(_ => LosePanel.SetActive(true));
	}
}
