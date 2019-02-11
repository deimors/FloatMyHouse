using Assets.Code.Model.Rewards;
using UnityEngine;
using Zenject;

public class CoinPresenter : MonoBehaviour
{
	[Inject]
	public Rewards RewardsModel { get; private set; }

	void OnTriggerEnter2D(Collider2D collision)
	{
		RewardsModel.AddCoin();
		Destroy(gameObject);
	}
}
