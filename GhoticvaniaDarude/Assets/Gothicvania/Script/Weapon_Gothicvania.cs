using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gothicvania : MonoBehaviour
{

    [SerializeField] GameObject Bullet;

    [SerializeField] float time_spawn, spawnTime;

    [SerializeField] AudioSource shootFX;


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && Player_Gothicvania._instance.CanShoot())
        {

            Invoke("Fire", spawnTime);


        }

    }




    public void Fire()
    {

        if (Time.time >= time_spawn)
        {
            if (!Player_Gothicvania._instance.PlayerFlip())
            {


                Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

                Bullet.GetComponent<SpriteRenderer>().flipX = false;

                shootFX.Play();

                time_spawn += spawnTime;
            }


            else
            {

                Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);


                Bullet.GetComponent<SpriteRenderer>().flipX = true;

                shootFX.Play();

                time_spawn += spawnTime;
            }


        }

    }
}
