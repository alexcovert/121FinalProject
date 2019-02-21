﻿using UnityEngine;

//https://answers.unity.com/questions/23010/ai-wandering-script.html
public class Wander : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int range;

    private Vector3 wayPoint;

    void Start()
    {
        SetDestination();
    }

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
        if ((transform.position - wayPoint).magnitude < 3)
        {
            // when the distance between us and the target is less than 3
            // create a new way point target
            SetDestination();
        }
    }

    void SetDestination()
    {
        wayPoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 
                                            transform.position.y, 
                                            Random.Range(transform.position.z - range, transform.position.z + range));
        
        transform.LookAt(wayPoint);
    }
}
