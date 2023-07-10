using UnityEngine;
using UnityEngine.UI;

public class BuildGUI : MonoBehaviour
{
	[SerializeField] private GameObject PanelBuildGUI;

	[SerializeField] private GameObject Eat;
	[SerializeField] private GameObject Wood;
	[SerializeField] private GameObject Scrap;
	[SerializeField] private GameObject Electronics;

	[SerializeField] private bool ActiviteIconGUI;

	static internal bool ActiviteBuildGUI;

	private void Update()
	{
		PanelBuildGUI.SetActive(ActiviteBuildGUI);

		if (Build.FlyBuildObject != null)
		{
			ActiviteBuildGUI = false;
		}

		ActiveIcons();
	}

	internal void OpenWorkbenchGUI()
	{
		ActiviteBuildGUI = true;
	}

	public void CloseWorkbenchGUI()
	{
		ActiviteBuildGUI = false;
	}

	public void OnPointerEnter(BuildItem buildItem)
	{
		ActiviteIconGUI = true;

		Eat.GetComponentInChildren<Text>().text = buildItem.Eat.ToString();
		Wood.GetComponentInChildren<Text>().text = buildItem.Wood.ToString();
		Scrap.GetComponentInChildren<Text>().text = buildItem.Scrap.ToString();
		Electronics.GetComponentInChildren<Text>().text = buildItem.Electronics.ToString();
	}

	public void OnPointerExit()
	{
		ActiviteIconGUI = false;
	}

	public void ActiveIcons()
	{
		Eat.SetActive(ActiviteIconGUI);
		Wood.SetActive(ActiviteIconGUI);
		Scrap.SetActive(ActiviteIconGUI);
		Electronics.SetActive(ActiviteIconGUI);
	}
}
