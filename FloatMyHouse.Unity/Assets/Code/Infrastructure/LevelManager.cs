using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelManager : MonoBehaviour
{
	public List<string> Levels;
	
	[Inject]
	public ZenjectSceneLoader SceneLoader { get; private set; }

	private int? _currentLevel;

	private string CurrentLevel
	{
		get => Levels[_currentLevel ?? throw new InvalidOperationException("No Current Level")];
	}

	void Start()
	{
		if (_currentLevel == null)
		{
			if (!Levels.Any())
				Debug.LogError($"No {nameof(Levels)} defined in {nameof(LevelManager)}");
			else
			{
				LoadFirstLevel();
			}
		}
	}
	
	public void NextLevel()
	{
		if (_currentLevel.HasValue)
		{
			string previousLevel = CurrentLevel;

			_currentLevel++;

			var unloadOp = SceneManager.UnloadSceneAsync(previousLevel);
			
			unloadOp.completed += UnloadCompleted;
		}
		else
		{
			LoadFirstLevel();
		}
	}

	public void Reload()
	{
		var unloadOp = SceneManager.UnloadSceneAsync(CurrentLevel);

		unloadOp.completed += UnloadCompleted;
	}

	private void UnloadCompleted(AsyncOperation unloadOp)
	{
		unloadOp.completed -= UnloadCompleted;
		LoadCurrentLevel();
	}

	private void LoadFirstLevel()
	{
		_currentLevel = 0;
		LoadCurrentLevel();
	}

	private void LoadCurrentLevel()
	{
		SceneLoader.LoadSceneAsync(CurrentLevel, LoadSceneMode.Additive);
	}
}
