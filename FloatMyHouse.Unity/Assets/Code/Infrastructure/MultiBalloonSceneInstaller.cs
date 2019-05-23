using Assets.Code.Model.Balloon;
using Zenject;

public class MultiBalloonSceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<House>().AsSingle();
	}
}