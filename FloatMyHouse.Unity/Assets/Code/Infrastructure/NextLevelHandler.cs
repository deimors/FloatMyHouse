using Assets.Code.Model.Game;
using UniRx;
using Zenject;

public class NextLevelHandler
{
	[Inject]
	public void Initialize(Game gameModel, [InjectOptional]LevelManager levelManager)
	{
		if (levelManager != null)
			gameModel.Events.OfType<GameEvent, NextLevelRequestedEvent>().Subscribe(_ => levelManager.NextLevel());
	}
}
