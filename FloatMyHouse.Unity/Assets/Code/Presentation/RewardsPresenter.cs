using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RewardsPresenter : MonoBehaviour
{
	public Text CoinCountText;
	
	[Inject]
	public void Initialize(Rewards rewardsModel)
	{
		rewardsModel.Events
			.OfType<RewardsEvent, CoinAddedEvent>()
			.Subscribe(e => CoinCountText.text = $"x {e.CoinCount}");
	}
}