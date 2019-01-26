using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaterPresenter : MonoBehaviour
{
	[Inject]
	public Game GameModel { get; private set; }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameModel.Lose();
	}
}
