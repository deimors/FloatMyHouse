using Assets.Code.Model.Game;
using UniRx;
using UnityEngine;
using Zenject;

public class GameOverPanelPresenter : MonoBehaviour
{
	public GameObject LosePanel;
	public GameObject WinPanel;

	[Inject]
	public void Initialize(Game gameModel)
	{
		gameModel.Events.OfType<GameEvent, GameLostEvent>().Subscribe(_ => LosePanel.SetActive(true));
		gameModel.Events.OfType<GameEvent, GameWonEvent>().Subscribe(_ => WinPanel.SetActive(true));
	}
}
