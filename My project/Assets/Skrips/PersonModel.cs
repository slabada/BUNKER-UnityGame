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
		�haracterizationSleep();

		�haracterizationHunger();

		Dead();
	}

	private void �haracterizationSleep()
	{
		StatusPerson += "\n" + �haracterization(ref DesireSleep, "�����");

		if (Sleep == true)
		{
			DesireSleep -= 4;

			if (DesireSleep < 0) DesireSleep = 0;
		}

		DesireSleep++;
	}

	private void �haracterizationHunger()
	{
		StatusPerson += "\n" + �haracterization(ref DesireSleep, "����");

		Hunger++;
	}

	private string �haracterization(ref int data, string text)
	{
		switch (data)
		{
			case 2:
				return $"- ����� {text}";
			case 3:
				return $"- ����� ����� {text}";
			case 4:
				return $"- ������� ��� ����� {text}";
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