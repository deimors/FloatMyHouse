using UniRx;
using Zenject;

public class NextLevelHandler
{
	[Inject]
	public void Initialize(Game gameModel, LevelManager levelManager)
	{
		gameModel.Events.OfType<GameEvent, NextLevelRequestedEvent>().Subscribe(_ => levelManager.NextLevel());
	}
}
