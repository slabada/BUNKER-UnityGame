using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonModel : MonoBehaviour
{
	public string Name;

	public bool Sleep = false;

	public bool Farming = false;

	public bool Mine = false;

	public int DesireSleep = 0;

	public int Hunger = 0;

	public string StatusPerson;

	public void WishesPerson()
	{
		ÑharacterizationSleep();

		ÑharacterizationHunger();

		Dead();
	}

	private void ÑharacterizationSleep()
	{
		StatusPerson += "\n" + Ñharacterization(ref DesireSleep, "ñïàòü");

		if (Sleep == true)
		{
			DesireSleep -= 4;

			if (DesireSleep < 0) DesireSleep = 0;
		}

		DesireSleep++;
	}

	private void ÑharacterizationHunger()
	{
		StatusPerson += "\n" + Ñharacterization(ref DesireSleep, "åñòü");

		Hunger++;
	}

	private string Ñharacterization(ref int data, string text)
	{
		switch (data)
		{
			case 2:
				return $"- Õî÷åò {text}";
			case 3:
				return $"- Î÷åíü õî÷åò {text}";
			case 4:
				return $"- Óìèðàåò êàê õî÷åò {text}";
		}

		return null;
	}

	private void Dead()
	{
		if(DesireSleep >= 5 || Hunger >= 5)
		{
			Destroy(this.gameObject);
		}
	}
}