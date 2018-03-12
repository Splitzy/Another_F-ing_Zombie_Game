using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour {

    public float speed;
    public float destroyTime;

	void OnEnable()
    {
        Invoke("Die", destroyTime);
	}

    void Die()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke("Die");
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}
}
