using Assets.Code.Model.Game;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinPanelPresenter : MonoBehaviour
{
	public Button RetryButton;
	public Button NextLevelButton;

	[Inject]
	public void Initialize(Game gameModel)
	{
		RetryButton.onClick.AddListener(() => gameModel.RestartLevel());
		NextLevelButton.onClick.AddListener(() => gameModel.NextLevel());
	}
}
