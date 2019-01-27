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

		balloonModel.Events
			.OfType<BalloonEvent, RefueledEvent>()
			.Subscribe(UpdateFuelLevel);
	}
	
	private void InitializeFuelLevel(InitializedEvent initEvent)
	{
		_maxFuelLevel = initEvent.MaxFuelLevel;
		FuelSlider.value = initEvent.CurrentFuelLevel / initEvent.MaxFuelLevel;
	}

	private void UpdateFuelLevel(FuelConsumedEvent consumedEvent)
	{
		UpdateFuelLevel(consumedEvent.NewFuelLevel);
	}
	
	private void UpdateFuelLevel(RefueledEvent refueledEvent)
	{
		UpdateFuelLevel(refueledEvent.NewFuelAmount);
	}

	private void UpdateFuelLevel(float newFuelLevel)
	{
		FuelSlider.value = newFuelLevel / _maxFuelLevel;
	}
}
