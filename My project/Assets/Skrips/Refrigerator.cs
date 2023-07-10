using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
	private Transform refrigerator;

	private bool isHunger = false;

	public void SetTargetRefrigerator(Transform refrigerator)
	{
		this.refrigerator = refrigerator;
	}

	void Update()
    {
        if(GameManager.person != null && 
			refrigerator != null &&
			this.transform.position.x == GameManager.person.transform.position.x)
        {
			if (!isHunger && Data.Eat > 0 && GameManager.person.GetComponent<PersonModel>().Hunger > 0)
			{
				Data.Eat--;

				GameManager.person.GetComponent<PersonModel>().Hunger--;

				isHunger = true;
			}
        }
		else
		{
			if (isHunger)
			{
				isHunger = false;
			}
		}
	}
}
