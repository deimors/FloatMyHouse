using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPresenter : MonoBehaviour
{
	private const string TextureName = "_MainTex";

	public float TextureScale = 4;

	public Vector2 Offset = Vector2.zero;
	public Vector2 Scale = new Vector2(.1f, .01f);

	public MeshRenderer MeshRenderer;

	private Vector2 _origOffset;

	void Start()
	{
		_origOffset = MeshRenderer.sharedMaterial.GetTextureOffset(TextureName);
	}

	void LateUpdate()
	{
		var cameraScale = Camera.main.orthographicSize / 2;

		var newOffset = new Vector2(((transform.position.x * Scale.x) + Offset.x), (transform.position.y * Scale.y) + Offset.y - (cameraScale * .1f));
		MeshRenderer.material.SetTextureOffset(TextureName, newOffset);
		

		
		transform.localScale = new Vector3(cameraScale, cameraScale, cameraScale);

		MeshRenderer.material.SetTextureScale(TextureName, new Vector2(cameraScale / TextureScale, cameraScale / TextureScale));
	}
}
