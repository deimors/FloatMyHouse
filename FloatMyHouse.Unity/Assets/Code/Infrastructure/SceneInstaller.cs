using System;
using UniRx;
using Zenject;

public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<Balloon>().AsSingle();

		Container.Bind<Game>().AsSingle();

		Container.Bind<IObservable<TimeTickEvent>>().FromInstance(Observable.EveryUpdate().Select(_ => new TimeTickEvent())).AsSingle();
	}
}
