using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponsManager : MonoBehaviour 
{
	Transform current = null;

	void Start() 
	{
		ChangeWeapon(0);
	}

	public void ChangeWeapon (int index) 
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(i == index)
			{
				current = transform.GetChild(index);
				current.gameObject.SetActive(true);
			}
			else 
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}	
	}
	
	public void Fire () 
	{
		current.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
	}
}
