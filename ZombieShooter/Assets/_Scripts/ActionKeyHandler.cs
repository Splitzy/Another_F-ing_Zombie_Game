using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ActionKeyHandler : MonoBehaviour 
{
	public KeyCode actionKey = KeyCode.None;

	public UnityEvent onKeyDown;
	
	public UnityEvent onKey;

	public UnityEvent onKeyUp;

	void Update () 
	{
		if(Input.GetKeyDown(actionKey))
		{
			onKeyDown.Invoke();
		}

		if(Input.GetKey(actionKey))
		{
			onKey.Invoke();
		}

		if(Input.GetKeyUp(actionKey))
		{
			onKeyUp.Invoke();
		}
	}
}
