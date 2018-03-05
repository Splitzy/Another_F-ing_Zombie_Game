using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour {

    public float speed;
    public float destroyTime;

	void Start()
    {
        Invoke("Die", destroyTime);
	}

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        CancelInvoke("Die");
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}
}
