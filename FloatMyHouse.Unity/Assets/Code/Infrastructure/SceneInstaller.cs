﻿using System;
using Assets.Code.Model;
using Assets.Code.Model.Balloon;
using Assets.Code.Model.Game;
using Assets.Code.Model.Rewards;
using UniRx;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<Balloon>().AsSingle();
		Container.Bind<Game>().AsSingle();
		Container.Bind<Rewards>().AsSingle();

		Container.Bind<IObservable<TimeTickEvent>>().FromInstance(CreateTimeStream()).AsSingle();

		Container.Bind<RestartLevelHandler>().AsSingle().NonLazy();
		Container.Bind<NextLevelHandler>().AsSingle().NonLazy();
	}

	private static IObservable<TimeTickEvent> CreateTimeStream() 
		=> Observable.EveryUpdate().Select(_ => new TimeTickEvent(Time.deltaTime));
}
