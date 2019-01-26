using UniRx;
using UnityEngine;
using Zenject;

public class CameraPresenter : MonoBehaviour
{
	public float Padding = 2f;
	public float MinHeight = 5f;

	public Camera Camera;

	private Vector2 _goalPosition;

	[Inject]
	public void Initialize(Game gameModel, Balloon balloonModel)
	{
		gameModel.Events
			.OfType<GameEvent, GoalPositionInitializedEvent>()
			.Subscribe(e => _goalPosition = e.Position);

		balloonModel.Events
			.OfType<BalloonEvent, PositionUpdatedEvent>()
			.Subscribe(UpdateCamera);
	}

	private void UpdateCamera(PositionUpdatedEvent updatedEvent)
	{
		var goalVector = _goalPosition - updatedEvent.NewPosition;

		Camera.orthographicSize = GetTargetOrthographicSize(goalVector);
		Camera.transform.position = GetTargetCameraPosition(updatedEvent.NewPosition, goalVector);
	}

	private Vector3 GetTargetCameraPosition(Vector2 newPosition, Vector2 goalVector)
	{
		var origZ = Camera.transform.position.z;

		var newCameraPos = (Vector3)(newPosition + (goalVector * .5f));
		newCameraPos.z = origZ;

		return newCameraPos;
	}

	private float GetTargetOrthographicSize(Vector2 goalVector)
	{
		var targetHeight = Mathf.Max(GetTargetHeightFromWidth(goalVector), GetTargetHeightFromHeight(goalVector));

		return Mathf.Max(targetHeight, MinHeight) + Padding;
	}

	private float GetTargetHeightFromHeight(Vector2 goalVector)
	{
		return Mathf.Abs(goalVector.y) * .5f;
	}

	private float GetTargetHeightFromWidth(Vector2 goalVector)
	{
		return (Mathf.Abs(goalVector.x) / Camera.aspect) * .5f;
	}
}
