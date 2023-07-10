using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndOfStroke : MonoBehaviour
{
	public UnityEvent EventNextDay;

	static internal int Day;

	public GameObject Panel;

	public GameObject PanelDay;

	public Animator BlackoutAnim;

	private Image Blackout;

	public Text DayText;

	private bool eventInvoked = false;

	private void Start()
	{
		Blackout = Panel.GetComponent<Image>();
	}

	private void Update()
	{
		if (Panel.activeSelf == true && BlackoutAnim.GetBool("ActionBlackout") == false && Blackout.color.a == 0)
		{
			Panel.SetActive(false);

			eventInvoked = false;
		}

		if (Blackout.color.a == 1)
		{
			BlackoutAnim.SetBool("ActionBlackout", false);
		}

		if (Blackout.color.a == 1 && !eventInvoked)
		{
			eventInvoked = true;

			EventNextDay?.Invoke();
		}
	}

	public void NextDay()
	{
		Day++;

		DayText.text = $"день {Day}";

		GameManager.person = null;

		BlackoutPanel();
	}

	private void BlackoutPanel()
	{
		Panel.SetActive(true);

		if (Panel.activeSelf == true)
		{
			BlackoutAnim.SetBool("ActionBlackout", true);
		}
	}
}
