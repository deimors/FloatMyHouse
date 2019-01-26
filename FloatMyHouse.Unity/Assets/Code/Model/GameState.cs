using System;

public abstract class GameState
{
	public abstract TResult Match<TResult>(
		Func<Playing, TResult> playing,
		Func<Won, TResult> won,
		Func<Lost, TResult> lost
	);

	public class Playing : GameState
	{
		public override TResult Match<TResult>(Func<Playing, TResult> playing, Func<Won, TResult> won, Func<Lost, TResult> lost)
			=> playing(this);
	}

	public class Won : GameState
	{
		public override TResult Match<TResult>(Func<Playing, TResult> playing, Func<Won, TResult> won, Func<Lost, TResult> lost)
			=> won(this);
	}

	public class Lost : GameState
	{
		public override TResult Match<TResult>(Func<Playing, TResult> playing, Func<Won, TResult> won, Func<Lost, TResult> lost)
			=> lost(this);
	}
}
