using Assets.Code.Model.Balloon;
using UniRx;
using UnityEngine;
using Zenject;

public class MultiBalloonPresenter : MonoBehaviour
{
	public SpringJoint2D SpringJoint;

	[Inject]
	public void Initialize(House houseModel)
	{
		var id = new BalloonIdentifier();

		houseModel.Attach(id, Height);
		
		houseModel.Events
			.OfType<HouseEvent, BalloonDetachedEvent>()
			.Where(e => e.BalloonId == id)
			.TakeUntilDestroy(gameObject)
			.Subscribe(_ => Detach());
	}

	private float Height => transform.localPosition.y;

	private void Detach()
	{
		SpringJoint.enabled = false;
	}
}