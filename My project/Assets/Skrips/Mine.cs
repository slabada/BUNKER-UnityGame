using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
	[SerializeField] internal List<PersonModel> PersoneMine = new List<PersonModel>();

	[Range(0, 100)]
	[SerializeField] private int Eat;

	[Range(0, 100)]
	[SerializeField] private int Wood;

	[Range(0, 100)]
	[SerializeField] private int Scrap;

	[Range(0, 100)]
	[SerializeField] private int Electronics;

	public void Sending()
	{
		for (int i = 0; i < PersoneMine.Count; i++)
		{
			PersoneMine[i].gameObject.SetActive(false);
		}
	}

	public void Returning()
	{
		for (int i = 0; i < PersoneMine.Count; i++)
		{
			if (Random.Range(0,6) == 0)
			{
				Debug.Log("NoDead");

				PersoneMine[i].gameObject.SetActive(true);

				PersoneMine.RemoveAt(i);

				AddResurse();
			}
			else
			{
				DeadPerson(i);
			}
		}
	}

	private void AddResurse()
	{
		if (Random.Range(0, 101) <= Eat)
		{
			Data.Eat += Random.Range(0, 20);
		}

		if (Random.Range(0, 101) <= Wood)
		{
			Data.Wood += Random.Range(0, 20);
		}

		if (Random.Range(0, 101) <= Scrap)
		{
			Data.Scrap += Random.Range(0, 20);
		}

		if (Random.Range(0, 101) <= Electronics)
		{
			Data.Electronics += Random.Range(0, 20);
		}
	}

	private void DeadPerson(int i)
	{
		if (Random.Range(0, 6) == 0)
		{
			Debug.Log("Dead");

			Destroy(PersoneMine[i].gameObject);

			PersoneMine.RemoveAt(i);
		}
	}
}
