using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    public int health = 10;
    public int damage = 2;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;
    public Material flashMaterial;
    Material original;
    SpriteRenderer sprite;

    private Transform player;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        original = sprite.material;

        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;

            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget2D>().target = player;
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("TakeDamage", damage);
            GetComponent<Collider2D>().enabled = false;
            Invoke("ResetDamage", 0.5f);
        }
    }


    void ResetDamage()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        DoDamageFlash();

        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 transform.eulerAngles.z + adjustExplosionAngle);

            Instantiate(explosionPrefab, transform.position, newRot);

            GetComponent<AddScore>().DoSendScore();

            Destroy(gameObject);
            CancelInvoke("ResetDamageFlash");
        }

    }

    public void DoDamageFlash()
    {
        sprite.material = flashMaterial;

        Invoke("ResetDamageFlash", 0.05f);
    }

    void ResetDamageFlash()
    {
        sprite.material = original;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }
}
