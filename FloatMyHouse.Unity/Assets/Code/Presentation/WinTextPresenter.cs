using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinTextPresenter : MonoBehaviour
{
	public Text WinText;

	[Inject]
	public void Initialize(Game gameModel)
	{
		gameModel.Events.OfType<GameEvent, GameWonEvent>().Subscribe(_ => ShowWinText());
	}

	private void ShowWinText()
	{
		WinText.enabled = true;
	}
}
