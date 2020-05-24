using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] Transform destination;

    [SerializeField] GameObject destinationFirst;

    [SerializeField] GameObject destinationSecond;

    [SerializeField] bool changeDestination;

    void Start()
    {
        
    }

    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(this.transform.position, destination.position, speed * Time.deltaTime);


        if (this.transform.position == destination.transform.position && !changeDestination)
        {

            destination = destinationSecond.transform;
            changeDestination = true;
        }

        else if (this.transform.position == destination.transform.position && changeDestination)
        {
            destination = destinationFirst.transform;
            changeDestination = false;


        }






    }
}
