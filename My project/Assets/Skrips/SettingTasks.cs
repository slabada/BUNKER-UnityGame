using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTasks : MonoBehaviour
{
	public Toggle ToggleSleep;

	public Toggle ToggleFarming;

	public Toggle ToggleMine;

	public Toggle[] Toggles;

	private void Start()
	{
		Toggles = new Toggle[] { ToggleSleep, ToggleFarming, ToggleMine};
	}

	private void Update()
	{
		MutualExclusivity();

		if (GameManager.person != null)
		{
			sbyte numberSleep = Data.NumberBeds;
			UpdateUI(ref ToggleSleep,ref numberSleep, ref GameManager.person.GetComponent<PersonModel>().Sleep, "Спать");

			sbyte numberFarming = Data.NumberFarming;
			UpdateUI(ref ToggleFarming,ref numberFarming, ref GameManager.person.GetComponent<PersonModel>().Farming, "Земледелие");

			ToggleMine.isOn = GameManager.person.GetComponent<PersonModel>().Mine;
		}
	}

	public void UpdateUI(ref Toggle toggle,ref sbyte data, ref bool status, string text)
	{
		toggle.GetComponentInChildren<Text>().text = $"{text} ({data})";
		toggle.isOn = status;
	}

	private void PlaceCounter(ref Toggle toggle, ref sbyte data, ref bool status, string text)
	{
		if (GameManager.person != null)
		{
			if (toggle.isOn == true && data > 0 && status == false)
			{
				status = true;

				data--;

				toggle.GetComponentInChildren<Text>().text = $"{text} ({data})";
			}
			else if (toggle.isOn == false && status == true)
			{
				status = false;

				data++;

				toggle.GetComponentInChildren<Text>().text = $"{text} ({data})";
			}
		}
	}

	public void Sleeping()
	{
		if (GameManager.person != null)
		{
			sbyte number = Data.NumberBeds;
			PlaceCounter(ref ToggleSleep, ref number, ref GameManager.person.GetComponent<PersonModel>().Sleep, "Спать");
			Data.NumberBeds = number;
		}
	}

	public void Farming()
	{
		if (GameManager.person != null)
		{
			sbyte number = Data.NumberFarming;
			PlaceCounter(ref ToggleFarming, ref number, ref GameManager.person.GetComponent<PersonModel>().Farming, "Земледелие");
			Data.NumberFarming = number;
		}
	}

	public void Mine()
	{
		if (GameManager.person != null)
		{
			if (ToggleMine.isOn == true && GameManager.person.GetComponent<PersonModel>().Mine == false)
			{
				GameManager.person.GetComponent<PersonModel>().Mine = true;
			}
			else if(ToggleMine.isOn == false && GameManager.person.GetComponent<PersonModel>().Mine == true)
			{
				GameManager.person.GetComponent<PersonModel>().Mine = false;
			}
		}
	}

	private void MutualExclusivity()
	{
		foreach (var toggle in Toggles)
		{
			if (toggle.isOn)
			{
				foreach (var otherToggle in Toggles)
				{
					if (otherToggle != toggle)
					{
						otherToggle.interactable = false;
					}
				}
				break;
			}
			else
			{
				foreach (var otherToggle in Toggles)
				{
					if (otherToggle != toggle)
					{
						otherToggle.interactable = true;
					}
				}
			}
		}
	}
}
