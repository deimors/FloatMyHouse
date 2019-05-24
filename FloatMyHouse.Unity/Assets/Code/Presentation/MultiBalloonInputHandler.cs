using Assets.Code.Model.Balloon;
using UniRx;
using UnityEngine;
using Zenject;

public class MultiBalloonInputHandler : MonoBehaviour
{
	public KeyCode DetachBalloonKey = KeyCode.UpArrow;
	public KeyCode DetachBagKey = KeyCode.DownArrow;

	[Inject]
	public House HouseModel { private get; set; }
	
	void Update()
	{
		if (Input.GetKeyDown(DetachBalloonKey))
			HouseModel.DetachBalloon();

		if (Input.GetKeyDown(DetachBagKey))
			HouseModel.DetachBag();
	}
}