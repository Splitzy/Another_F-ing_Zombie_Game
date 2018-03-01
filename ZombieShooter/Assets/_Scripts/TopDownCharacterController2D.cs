using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class TopDownCharacterController2D : MonoBehaviour {

    public float speed;
    public float sprint;
    private Rigidbody2D rb2D;
    public Boundary boundary;

	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb2D.velocity = new Vector2(x, y) * sprint;
        }
        else
        {
            rb2D.velocity = new Vector2(x, y) * speed;
        }

        rb2D.angularVelocity = 0.0f;

        rb2D.position = new Vector2
            (
                Mathf.Clamp(rb2D.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb2D.position.y, boundary.yMin, boundary.yMax)
            );
	}
}
