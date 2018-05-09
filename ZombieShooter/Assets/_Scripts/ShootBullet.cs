using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public Transform bulletSpawnRight;
    //public Transform bulletSpawnLeft;
    public float fireTime;
    public string pooledObject;
    private bool isFiring = false;


    

    void SetFiring()
    {
        isFiring = false;

        GetComponent<Animator>().SetBool("Is Firing", false);
    }


    void Fire()
    {
        isFiring = true;
        GameObject bullet = PoolManager.current.GetPooledObject(pooledObject);

        if(bullet != null)
        {
            bullet.transform.position = bulletSpawnRight.position;
            bullet.transform.rotation = bulletSpawnRight.rotation;
            
            bullet.SetActive(true);
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        GetComponent<Animator>().SetBool("Is Firing", true);

        Invoke("SetFiring", fireTime);
    }

	void Update ()
    {
		if(Input.GetMouseButton(0) && !PauseMenu.isPaused)
        {
            if(!isFiring)
            {
                Fire();
            }
        }
	}
}
