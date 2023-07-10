using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static internal GameObject person;

	internal GameObject TargetLooting;

	internal GameObject workbench;

	internal GameObject Refrigerator;

	public List<GameObject> Sleep = new List<GameObject>();

	public List<GameObject> Farming = new List<GameObject>();

	public List<PersonModel> Persone = new List<PersonModel>();

	private void Start()
	{
		Persone = FindObjectsOfType<PersonModel>().ToList();
	}

	private void Update()
	{
		GameOver();

		ValidData();

		GetPerson();

		GetTargetLootig();

		GetWorkbench();

		GetRefrigerator();
	}

	private void GameOver()
	{
		if(Persone.Count == 0)
		{
			Debug.Log("GameOver");
		}
	}

	private void ValidData()
	{
		Data.NumberBeds = Data.NumberBeds < (sbyte)0 ? (sbyte)0 : Data.NumberBeds;

		for (int i = 0; i < Persone.Count; i++)
		{
			if (Persone[i] == null)
			{
				Persone.RemoveAt(i);
			}
		}
	}

	private void GetPerson()
	{
		if (GettingObject.hit.collider != null)
		{
			PersonModel personCheck = GettingObject.hit.collider.GetComponent<PersonModel>();

			if (personCheck != null)
			{
				person = GettingObject.hit.collider.gameObject;
			}

			if (Input.GetMouseButtonDown(1))
			{
				person = null;
			}
		}
	}

	private void GetTargetLootig()
	{
		if (GettingObject.hit.collider != null)
		{
			Loot boxCheck = GettingObject.hit.collider.GetComponent<Loot>();

			if (boxCheck != null && person != null)
			{
				TargetLooting = GettingObject.hit.collider.gameObject;

				person.GetComponent<Move>().SetMoveToPoint(TargetLooting.transform.position);

				person.GetComponent<Looting>().SetTargetLooting(TargetLooting.transform);
			}
		}
	}

	private void GetWorkbench()
	{
		if (GettingObject.hit.collider != null)
		{
			Workbench WorkbenchCheck = GettingObject.hit.collider.GetComponent<Workbench>();

			if (WorkbenchCheck != null && person != null)
			{
				workbench = GettingObject.hit.collider.gameObject;

				person.GetComponent<Move>().SetMoveToPoint(workbench.transform.position);

				workbench.GetComponent<Workbench>().SetTargetWorkbench(workbench.transform);
			}
		}
	}

	private void GetRefrigerator()
	{
		if (GettingObject.hit.collider != null)
		{
			Refrigerator refrigeratorCheck = GettingObject.hit.collider.GetComponent<Refrigerator>();

			if (refrigeratorCheck != null && person != null)
			{
				Refrigerator = GettingObject.hit.collider.gameObject;

				person.GetComponent<Move>().SetMoveToPoint(Refrigerator.transform.position);

				Refrigerator.GetComponent<Refrigerator>().SetTargetRefrigerator(Refrigerator.transform);
			}
		}
	}
}
