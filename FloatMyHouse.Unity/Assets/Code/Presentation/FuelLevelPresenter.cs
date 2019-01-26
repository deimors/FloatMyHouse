using System;
using UniRx;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class FuelLevelPresenter : MonoBehaviour
{
	public Slider FuelSlider;

	private float _maxFuelLevel;

	[Inject]
	public void Initialize(Balloon balloonModel)
	{
		balloonModel.Events
			.OfType<BalloonEvent, InitializedEvent>()
			.Subscribe(InitializeFuelLevel);

		balloonModel.Events
			.OfType<BalloonEvent, FuelConsumedEvent>()
			.Subscribe(UpdateFuelLevel);
	}
	
	private void InitializeFuelLevel(InitializedEvent initEvent)
	{
		_maxFuelLevel = initEvent.MaxFuelLevel;
		FuelSlider.value = initEvent.CurrentFuelLevel / initEvent.MaxFuelLevel;
	}

	private void UpdateFuelLevel(FuelConsumedEvent consumedEvent)
	{
		FuelSlider.value = consumedEvent.NewFuelLevel / _maxFuelLevel;
	}
}
