using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPresenter : MonoBehaviour
{
	public Rigidbody2D BalloonRigidBody;
	public float Magnitude;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			AddUpForce(Magnitude);
		}

		AddUpForce(1);
	}

	private void AddUpForce(float force)
	{
		BalloonRigidBody.AddForce(Vector2.up * force);
	}
}
