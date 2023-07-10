using UnityEngine;
using UnityEngine.EventSystems;

public class SettingPointMove : MonoBehaviour
{
	private void Update()
	{
		GetMoveToPoint();
	}

	static internal void GetMoveToPoint()
	{
		if (Input.GetMouseButtonUp(0) && CameraController.IsCameraMoving == false)
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				Vector2 screenPoint = Input.mousePosition;

				Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

				if (hit.collider != null &&
					hit.collider.GetComponent<BoxCollider2D>() != null &&
					GameManager.person != null &&
					hit.collider.GetComponent<PersonModel>() == null)
				{
					GameManager.person.GetComponent<Move>().SetMoveToPoint(worldPoint);
				}
			}
		}
	}
}
