using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPresenter : MonoBehaviour
{
	private const string TextureName = "_MainTex";

	public float Scale = .1f;
	public MeshRenderer MeshRenderer;

	private Vector2 _origOffset;

	void Start()
	{
		_origOffset = MeshRenderer.sharedMaterial.GetTextureOffset(TextureName);
	}

	void LateUpdate()
	{
		var newOffset = new Vector2(transform.position.x * Scale, transform.position.y * Scale);
		MeshRenderer.sharedMaterial.SetTextureOffset(TextureName, newOffset);
	}
}
