using UnityEngine;
using UnityEngine.UI;

public class TasksGUI : MonoBehaviour
{
	public GameObject PanelTask;

	public Text Name;

	public Text ÑharacterizationText;

	private void Update()
	{
		if(GameManager.person != null)
		{
			this.gameObject.GetComponent<Button>().interactable = true;
		}
		else
		{
			this.gameObject.GetComponent<Button>().interactable = false;
		}
	}

	public void OpenTaskGUI()
	{
		PanelTask.SetActive(true);

		Name.text = GameManager.person.GetComponent<PersonModel>().Name;

		ÑharacterizationText.text = $"{GameManager.person.GetComponent<PersonModel>().StatusPerson}";
	}

	public void CloseTaskGUI()
	{
		PanelTask.SetActive(false);
	}
}
