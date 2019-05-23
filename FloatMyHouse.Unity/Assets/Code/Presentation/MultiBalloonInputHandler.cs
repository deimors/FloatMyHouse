using Assets.Code.Model.Balloon;
using UniRx;
using UnityEngine;
using Zenject;

public class MultiBalloonInputHandler : MonoBehaviour
{
	public KeyCode DetachKey = KeyCode.Space;

	[Inject]
	public void Initialize(House house)
	{
		Observable
			.EveryUpdate()
			.Where(_ => Input.GetKeyDown(DetachKey))
			.TakeUntilDestroy(gameObject)
			.Subscribe(_ => house.DetachHighest());
	}
}