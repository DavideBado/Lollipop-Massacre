using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
	public List<Sprite> Icons = new List<Sprite>();

	private void Start()
	{
		Cleaner();
	}

	public void OnAbility(int _AbilityID)
	{
		if (GetComponentInParent<SliderBehaviour>() != null)
		{
			GetComponentInParent<SliderBehaviour>().GetComponentInChildren<Fill>().GetComponent<Image>().enabled = false;
		}
		else if (GetComponentInParent<PointerSpritePosition>() != null)
		{
			GetComponentInParent<PointerSpritePosition>().GetComponent<RawImage>().enabled = false;
		}
		GetComponent<Image>().enabled = true;
		GetComponent<Image>().sprite = Icons[(_AbilityID - 1)];

		Cleaner();
	}

	void Cleaner()
	{ if(GetComponentInParent<SliderBehaviour>() != null)
	{
			GetComponentInParent<SliderBehaviour>().GetComponentInChildren<Fill>().GetComponent<Image>().enabled = true;
	}
	else if (GetComponentInParent<PointerSpritePosition>() != null)
		{
			GetComponentInParent<PointerSpritePosition>().GetComponent<RawImage>().enabled = true;
		}
		GetComponent<Image>().enabled = false;
	}
}
