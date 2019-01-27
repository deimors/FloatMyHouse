using UniRx;
using UnityEngine;
using Zenject;

public class CoinAudioPresenter : MonoBehaviour
{
	public AudioSource Source;

	[Inject]
	public void Initialize(Rewards rewardsModel)
	{
		rewardsModel.Events
			.OfType<RewardsEvent, CoinAddedEvent>()
			.Subscribe(_ => Source.Play());
	}
}