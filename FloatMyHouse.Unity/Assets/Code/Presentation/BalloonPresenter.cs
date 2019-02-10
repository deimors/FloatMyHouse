using UniRx;
using UnityEngine;
using Zenject;

public class BalloonPresenter : MonoBehaviour
{
	public Rigidbody2D BalloonRigidBody;
	public float ConstantForcePerSecond = 60;

	[Inject]
	public void Initialize(Balloon balloonModel)
	{
		balloonModel.Events
			.OfType<BalloonEvent, LiftAddedEvent>()
			.Subscribe(e => AddUpForce(e.Force));

		Observable.EveryLateUpdate()
			.Select(_ => (Vector2)transform.position)
			.Subscribe(balloonModel.UpdatePosition)
			.AddTo(gameObject);
	}

	void Update()
	{
		AddUpForce(ConstantForcePerSecond * Time.deltaTime);
	}

	private void AddUpForce(float force)
	{
		BalloonRigidBody.AddForce(Vector2.up * force);
	}
}
