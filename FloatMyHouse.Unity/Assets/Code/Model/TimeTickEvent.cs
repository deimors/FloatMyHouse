﻿namespace Assets.Code.Model
{
	public class TimeTickEvent
	{
		public float DeltaTime { get; }

		public TimeTickEvent(float deltaTime)
		{
			DeltaTime = deltaTime;
		}
	}
}
