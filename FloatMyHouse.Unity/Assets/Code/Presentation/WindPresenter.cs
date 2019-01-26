using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPresenter : MonoBehaviour
{
	public SpriteRenderer WindSprite;

	void Awake()
	{
		HideWind();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		ShowWind();
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		HideWind();
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