using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindPresenter : MonoBehaviour
{
	public SpriteRenderer WindSprite;

	[Inject]
	public Balloon BalloonModel;

	void Awake()
	{
		HideWind();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		ShowWind();
		BalloonModel.StartBlowing();
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		HideWind();
		BalloonModel.EndBlowing();
	}
	
	private void ShowWind()
	{
		WindSprite.enabled = true;
	}

	private void HideWind()
	{
		WindSprite.enabled = false;
	}
}