using UniRx;
using UnityEngine;
using Zenject;

public class BalloonPresenter : MonoBehaviour
{
	public Rigidbody2D BalloonRigidBody;
	public float Magnitude;

	[Inject]
	public void Initialize(Balloon balloonModel)
	{
		balloonModel.Events
			.OfType<BalloonEvent, LiftAddedEvent>()
			.Subscribe(_ => AddUpForce(Magnitude));

		Observable.EveryLateUpdate()
			.Select(_ => (Vector2)transform.position)
			.Subscribe(balloonModel.UpdatePosition)
			.AddTo(gameObject);
	}

	void Update()
	{
		AddUpForce(1);
	}

	private void AddUpForce(float force)
	{
		BalloonRigidBody.AddForce(Vector2.up * force);
	}
}
