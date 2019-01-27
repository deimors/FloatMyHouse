using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelManager : MonoBehaviour
{
	public List<string> Levels;

	private string _loadedLevel;

	[Inject]
	public ZenjectSceneLoader SceneLoader { get; private set; }

	void Start()
	{
		if (_loadedLevel == null)
		{
			if (!Levels.Any())
				Debug.LogError($"No {nameof(Levels)} defined in {nameof(LevelManager)}");
			else
			{
				_loadedLevel = Levels.First();
				SceneLoader.LoadSceneAsync(_loadedLevel, LoadSceneMode.Additive);
			}
		}
	}

	public void Reload()
	{
		var unloadOp = SceneManager.UnloadSceneAsync(_loadedLevel);

		unloadOp.completed += UnloadCompleted;
	}

	private void UnloadCompleted(AsyncOperation unloadOp)
	{
		unloadOp.completed -= UnloadCompleted;

		SceneLoader.LoadSceneAsync(_loadedLevel, LoadSceneMode.Additive);
	}
}
