using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
	private const KeyCode liftKey = KeyCode.Space;

	[Inject]
	public Balloon BalloonModel { get; private set; }

	void Update()
	{
		if (Input.GetKeyDown(liftKey))
		{
			BalloonModel.StartLift();
		}
		else if (Input.GetKeyUp(liftKey))
		{
			BalloonModel.EndLift();
		}
	}
}
