using UnityEngine;
using Zenject;

public class GoalIslandPresenter : MonoBehaviour
{
	public LayerMask CollisionMask;

	[Inject]
	public Game GameModel { get; private set; }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (IsCollisionWithHouse(collision))
			GameModel.Win();
	}

	private bool IsCollisionWithHouse(Collision2D collision) 
		=> (CollisionMask.value & (1 << collision.gameObject.layer)) != 0;
}
