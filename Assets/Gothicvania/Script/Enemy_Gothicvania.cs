using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gothicvania : MonoBehaviour
{

    static public Enemy_Gothicvania _instance;

    [SerializeField] SpriteRenderer spriteR;

    [SerializeField] Animator anim;

    [SerializeField] int life;

    [SerializeField] float speed;

    [SerializeField] Transform destination;

    [SerializeField] GameObject destinationFirst;

    [SerializeField] GameObject destinationSecond;

    [SerializeField] bool changeDestination;

    [SerializeField] int damage;

    [SerializeField] bool die;

    [SerializeField] BoxCollider boxCol;

    [SerializeField] AudioSource soundDeath;


    private void Awake()
    {
     
        if(_instance == null)
        {
            _instance = this;
        }
        
    }


    void FixedUpdate()
    {

        Movement(speed);

        if (life <= 0)
        {
            Death();
        }

    }


    void Movement(float value)
    {
        
        transform.position = Vector3.MoveTowards(this.transform.position, destination.position, value * Time.deltaTime);


        if (this.transform.position == destination.transform.position && !changeDestination)
        {
            spriteR.flipX = false;

            destination = destinationSecond.transform;
            changeDestination = true;
        }

        else if (this.transform.position == destination.transform.position && changeDestination)
        {
            spriteR.flipX = true;
            destination = destinationFirst.transform;
            changeDestination = false;


        }
    }


    public void Death()
    {

            
            die = true;
            anim.SetBool("Die", true);
            speed = 0;
            boxCol.enabled = false;
            DestroyObject(this.gameObject, 2f);
           
                      

       
    }

    public void PlaySoundDeath()
    {
        soundDeath.Play();
    }

    
    
    public int Damage_Enemy()
    
    {
        return damage;

    }

    public int Get_Life(int value)
    {
        return life -= value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

        }
    }
}
