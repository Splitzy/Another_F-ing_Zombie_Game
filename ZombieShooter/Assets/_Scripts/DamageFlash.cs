using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class DamageFlash : MonoBehaviour 
{

    public Material flashMaterial;
    Material original;
    SpriteRenderer sprite;
    public GameObject Hero;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        original = sprite.material;
    }

    private void Update()
    {
        if(Hero.GetComponent<PlayerBehaviour>().isDamaged)
        {
            DoDamageFlash();
        }
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
