using System;
using UniRx;
using UnityEngine;

public class Game
{
	private ISubject<GameEvent> _events = new Subject<GameEvent>();
	public IObservable<GameEvent> Events => _events;

	private GameState _state = new GameState.Playing();

	public void Win()
	{
		_state.Match<Action>(
			playing => WinGame,
			won => () => { },
			lost => () => { }
		).Invoke();
	}

	public void NextLevel()
	{
		_events.OnNext(new NextLevelRequestedEvent());
	}

	public void Lose()
	{
		_state.Match<Action>(
			playing => LoseGame,
			won => () => { },
			lost => () => { }
		).Invoke();
	}

	public void RestartLevel()
	{
		_events.OnNext(new LevelRestartRequestedEvent());
	}
	
	private void WinGame()
	{
		_events.OnNext(new GameWonEvent());
		_state = new GameState.Won();
	}

	private void LoseGame()
	{
		_events.OnNext(new GameLostEvent());

		_state = new GameState.Lost();
	}

	public void InitializeGoalPosition(Vector2 position)
	{
		_events.OnNext(new GoalPositionInitializedEvent(position));
	}
}
