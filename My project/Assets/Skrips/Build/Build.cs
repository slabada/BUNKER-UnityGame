using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
	static internal BuildItem PrefabBuildObject;

	static internal BuildItem FlyBuildObject;

	static internal bool IsTrigger;

	private Vector2 MousePosition;

	public GameObject[] BuildZone;

	public Dictionary<string, List<GameObject>> builtObjectsDictionary;

	private void Update()
	{
		CheckBuildObject();

		Cancel();

		PositionBuildObject();

		InstallationBuildObject();
	}

	private void CheckBuildObject()
	{
		if (FlyBuildObject != null)
		{
			for (int i = 0; i < BuildZone.Length; i++)
			{
				BuildZone[i].SetActive(true);
			}
		}
		else
		{
			for (int i = 0; i < BuildZone.Length; i++)
			{
				BuildZone[i].SetActive(false);
			}
		}
	}

	public void CreaterFlyBuildObject(BuildItem flyBuildObject)
	{
		if (Data.Eat >= flyBuildObject.Eat &&
			Data.Wood >= flyBuildObject.Wood &&
			Data.Scrap >= flyBuildObject.Scrap &&
			Data.Electronics >= flyBuildObject.Electronics)
		{
			Data.Eat -= flyBuildObject.Eat;
			Data.Wood -= flyBuildObject.Wood;
			Data.Scrap -= flyBuildObject.Scrap;
			Data.Electronics -= flyBuildObject.Electronics;

			PrefabBuildObject = flyBuildObject;

			FlyBuildObject = Instantiate(flyBuildObject);

			FlyBuildObject.transform.position = MousePosition;
		}
	}

	private void PositionBuildObject()
	{
		if (IsTrigger == false)
		{
			MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (FlyBuildObject != null)
			{
				FlyBuildObject.transform.position = MousePosition;
			}
		}
	}

	private void InstallationBuildObject()
	{
		if (FlyBuildObject != null &&
			FlyBuildObject.BlockBuild == false &&
			IsTrigger == true &&
			Input.GetMouseButtonDown(0))
		{
			FlyBuildObject.AddBuildItem();

			FlyBuildObject = null;
		}
	}

	private void Cancel()
	{
		if (FlyBuildObject != null && Input.GetMouseButtonDown(1))
		{
			Data.Eat += PrefabBuildObject.Eat;
			Data.Wood += PrefabBuildObject.Wood;
			Data.Scrap += PrefabBuildObject.Scrap;
			Data.Electronics += PrefabBuildObject.Electronics;

			Destroy(FlyBuildObject.gameObject);
		}
	}
}
