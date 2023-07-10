using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPosition : MonoBehaviour
{
	private Vector2 MousePosition;

	private bool IsTrigger;

	private void Update()
	{
		if (Build.IsTrigger && IsTrigger)
		{
			MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector2.Distance(this.transform.position, MousePosition) > 5)
			{
				IsTrigger = false;

				Build.IsTrigger = IsTrigger;

			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<BuildItem>() != null)
		{
			IsTrigger = true;

			Build.IsTrigger = IsTrigger;

			collision.gameObject.transform.position = new Vector2(this.transform.position.x, Build.PrefabBuildObject.transform.position.y);
		}
	}
}
