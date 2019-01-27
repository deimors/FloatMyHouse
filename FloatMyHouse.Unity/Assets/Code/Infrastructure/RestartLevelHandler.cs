using UniRx;
using Zenject;

public class RestartLevelHandler
{
	[Inject]
	public void Initialize(Game gameModel, LevelManager levelManager)
	{
		gameModel.Events.OfType<GameEvent, LevelRestartRequestedEvent>().Subscribe(_ => levelManager.Reload());
	}
}
