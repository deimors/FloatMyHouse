using Assets.Code.Model.Balloon;
using UniRx;
using UnityEngine;
using Zenject;

public class BagPresenter : MonoBehaviour
{
	public HingeJoint2D HingeJoint;

	[Inject]
	public void Initialize(House houseModel)
	{
		var id = new BagIdentifier();

		houseModel.Attach(id, transform.localPosition.x);

		houseModel.Events
			.OfType<HouseEvent, BagDetachedEvent>()
			.Where(e => e.BagId == id)
			.TakeUntilDestroy(gameObject)
			.Subscribe(_ => HingeJoint.enabled = false);
	}
}