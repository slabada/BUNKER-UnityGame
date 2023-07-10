using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
	static public bool IsCameraMoving;

	public float movementSpeed = 5f;
	public float zoomSpeed = 5f;
	public float minSize = 10f;
	public float maxSize = 25f;
	public Vector2 boundaryMin;
	public Vector2 boundaryMax;

	private Vector3 lastMousePosition;
	private Vector3 oldPosition;
	private Vector3 newPosition;
	private Camera cameraComponent;

	void Start()
	{
		cameraComponent = GetComponent<Camera>();
	}

	void Update()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			if (Input.GetMouseButtonDown(0))
			{
				lastMousePosition = Input.mousePosition;

				oldPosition = this.transform.position;

				IsCameraMoving = false;
			}

			if (Input.GetMouseButton(0))
			{
				Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
				Vector3 movement = new Vector3(-deltaMousePosition.x, -deltaMousePosition.y, 0) * movementSpeed * Time.deltaTime;

				newPosition = transform.position + movement;

				newPosition.x = Mathf.Clamp(newPosition.x, boundaryMin.x, boundaryMax.x);
				newPosition.y = Mathf.Clamp(newPosition.y, boundaryMin.y, boundaryMax.y);

				oldPosition = this.transform.position;

				transform.position = newPosition;

				lastMousePosition = Input.mousePosition;

				if (newPosition != oldPosition)
				{
					IsCameraMoving = true;
				}
			}

			float scroll = Input.GetAxis("Mouse ScrollWheel");
			float newSize = cameraComponent.orthographicSize - scroll * zoomSpeed;
			newSize = Mathf.Clamp(newSize, minSize, maxSize);
			cameraComponent.orthographicSize = newSize;
		}
	}
}