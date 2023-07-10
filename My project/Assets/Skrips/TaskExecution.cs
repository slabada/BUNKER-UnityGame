using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskExecution : MonoBehaviour
{
	private GameManager gameManager;

	public int AddEatFarming;

	private Mine mine;

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();

		mine = FindObjectOfType<Mine>();
	}

	public void Execution()
	{
		Sleep();

		Farming();

		Mines();
	}

	private void Sleep()
	{
		foreach (var person in gameManager.Persone)
		{
			if(person.GetComponent<PersonModel>().Sleep == true)
			{
				person.GetComponent<PersonModel>().Sleep = false;

				Data.NumberBeds++;
			}
		}
	}

	private void Farming()
	{
		foreach (var person in gameManager.Persone)
		{
			if (person.GetComponent<PersonModel>().Farming == true)
			{
				Data.Eat += AddEatFarming;

				person.GetComponent<PersonModel>().Farming = false;

				Data.NumberFarming++;
			}
		}
	}

	private void Mines()
	{
		foreach (var person in gameManager.Persone)
		{
			if (person.GetComponent<PersonModel>().Mine == true)
			{
				mine.PersoneMine.Add(person);

				person.GetComponent<PersonModel>().Mine = false;

				mine.Sending();
			}
		}
	}
}
