using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
	[SerializeField] private Text EatText;
	[SerializeField] private Text WoodText;
	[SerializeField] private Text ScrapText;
	[SerializeField] private Text ElectronicsText;

	void Update()
	{
		UpdateResurseGUI();
	}

	private void UpdateResurseGUI()
	{
		EatText.text = Data.Eat.ToString();
		WoodText.text = Data.Wood.ToString();
		ScrapText.text = Data.Scrap.ToString();
		ElectronicsText.text = Data.Electronics.ToString();
	}
}
