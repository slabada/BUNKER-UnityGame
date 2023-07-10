using UnityEngine;

public class Workbench : MonoBehaviour
{
	private Transform workbench;

	private BuildGUI buildGUI;

	private bool isMenuOpen = false;

	private void Start()
	{
		buildGUI = FindAnyObjectByType<BuildGUI>();
	}

	public void SetTargetWorkbench(Transform workbench)
	{
		this.workbench = workbench;
	}

	void Update()
	{
		if (GameManager.person != null && 
			workbench != null && 
			this.transform.position.x == GameManager.person.transform.position.x)
		{
			if (!isMenuOpen)
			{
				buildGUI.OpenWorkbenchGUI();
				isMenuOpen = true;
			}
		}
		else
		{
			if (isMenuOpen)
			{
				buildGUI.CloseWorkbenchGUI();
				isMenuOpen = false;
			}
		}
	}
}
