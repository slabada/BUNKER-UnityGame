using UnityEngine;

public class BuildItem : MonoBehaviour
{
	private GameManager gameManager;

	internal bool BlockBuild;

	public int Eat;
	public int Wood;
	public int Scrap;
	public int Electronics;

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	public enum BuildItemType
	{
		Bed,
		Farming,
	}

	public BuildItemType ItemType;

	public void AddBuildItem()
	{
		switch (ItemType)
		{
			case BuildItemType.Bed:
				gameManager.Sleep.Add(this.gameObject);
				Data.NumberBeds++;
				break;
			case BuildItemType.Farming:
				gameManager.Farming.Add(this.gameObject);
				Data.NumberFarming++;
				break;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.GetComponent<BuildItem>() != null)
		{
			BlockBuild = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		BlockBuild = false;
	}
}
