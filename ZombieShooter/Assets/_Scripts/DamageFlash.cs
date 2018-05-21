using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class DamageFlash : MonoBehaviour 
{

    public Material flashMaterial;
    Material original;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        original = sprite.material;
    }

    public void DoDamageFlash () 
    {
        sprite.material = flashMaterial;
        Invoke("ResetDamageFlash", 0.1f);
	}
	
	void ResetDamageFlash () 
    {
        sprite.material = original;
	}

    void OnDestroy()
    {
        CancelInvoke("ResetDamageFlash");
    }
}
