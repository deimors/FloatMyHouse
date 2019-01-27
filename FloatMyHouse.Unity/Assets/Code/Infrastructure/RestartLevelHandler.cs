using UniRx;
using Zenject;

public class RestartLevelHandler
{
	[Inject]
	public void Initialize(Game gameModel, [InjectOptional]LevelManager levelManager)
	{
		if (levelManager != null)
			gameModel.Events.OfType<GameEvent, LevelRestartRequestedEvent>().Subscribe(_ => levelManager.Reload());
	}
}