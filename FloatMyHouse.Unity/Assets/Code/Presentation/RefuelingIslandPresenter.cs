using UnityEngine;
using Zenject;

public class RefuelingIslandPresenter : MonoBehaviour
{
	public LayerMask CollisionMask;

	[Inject]
	public Balloon BalloonModel { get; private set; }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (IsCollisionWithHouse(collision))
			BalloonModel.StartRefueling();
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (IsCollisionWithHouse(collision))
			BalloonModel.EndRefueling();
	}

	private bool IsCollisionWithHouse(Collider2D collider)
		=> (CollisionMask.value & (1 << collider.gameObject.layer)) != 0;
}