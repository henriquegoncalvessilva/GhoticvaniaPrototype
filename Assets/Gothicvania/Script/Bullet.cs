using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] int damage;

    [SerializeField] Rigidbody rig;

    [SerializeField] float speed;

    [SerializeField] Camera cam;

    [SerializeField] Sprite _sprite;


    private void Start()
    {

        rig = GetComponent<Rigidbody>();
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            rig.velocity = transform.right * speed;
        }
        else if (GetComponent<SpriteRenderer>().flipX)
        {
            rig.velocity = transform.right * -speed;

        }


    }

    private void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            rig.velocity = transform.right * speed;
        }
        else if (GetComponent<SpriteRenderer>().flipX)
        {
            rig.velocity = transform.right * -speed;

        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bug")
        {
           
            Destroy(this.gameObject);
        }

        else if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy_Gothicvania>().Get_Life(damage);
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreLayerCollision(15, 17);

        if (collision.gameObject.layer == 12)
        {

            Destroy(this.gameObject);

        }



    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("Destroyed");
    }



    public void EffectBullet()
    {
        Destroy(this.gameObject);
       
    }



}
