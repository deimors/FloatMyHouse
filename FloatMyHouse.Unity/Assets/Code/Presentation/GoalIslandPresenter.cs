using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using System;
using Assets.Code.Model.Game;

public class GoalIslandPresenter : MonoBehaviour
{
	public Collider2D Collider;
	public LayerMask CollisionMask;

	[Inject]
	public Game GameModel { get; private set; }

	void Start()
	{
		GameModel.InitializeGoalPosition(transform.position);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (IsCollisionWithHouse(collider))
			Observable.EveryUpdate()
				.Delay(TimeSpan.FromSeconds(1))
				.Take(1)
				.Where(_ => collider.IsTouching(Collider))
				.Subscribe(_ => GameModel.Win());
	}
	
	private bool IsCollisionWithHouse(Collider2D collider) 
		=> (CollisionMask.value & (1 << collider.gameObject.layer)) != 0;
}
