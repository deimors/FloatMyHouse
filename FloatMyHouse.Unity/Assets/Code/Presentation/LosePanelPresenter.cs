using System;
using Assets.Code.Model.Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LosePanelPresenter : MonoBehaviour
{
	public Button RetryButton;

	[Inject]
	public void Initialize(Game gameModel)
	{
		RetryButton.onClick.AddListener(() => gameModel.RestartLevel());
	}
}