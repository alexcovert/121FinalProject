﻿using UnityEngine;

//https://answers.unity.com/questions/23010/ai-wandering-script.html
public class Wander : MonoBehaviour
{
    [SerializeField]
    private bool prePlaced;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int range;

    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private Transform currentWaypoint;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pressSFX;
    [SerializeField] private AudioClip eatenSFX;

    private Vector3 wayPoint;
    private Score player;
    private LineOfSight sight;


    private int numTimesPressed = 0;

    void Start()
    {
        sight = GetComponent<LineOfSight>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<Score>();

        if(prePlaced)
            SetDestination();
    }

    void Update()
    {
        //If the player hasn't been seen, continue patrolling streets
        if (!sight.PlayerSeen)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
            if ((transform.position - wayPoint).magnitude < 0.1)
            {
                // when the distance between us and the target is less than 3
                // create a new way point target
                SetDestination();
            }
        }
        //If the player has been seen, and is in the overlap sphere, look at the player
        //TODO: Start a timer
        else if(Physics.OverlapSphere(transform.position, sight.SightDistance).Length > 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, sight.SightDistance);
            bool playerInSphere = false;
            for (int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].tag == "Player")
                {
                    transform.LookAt(colliders[i].transform);
                    playerInSphere = true;
                }
            }

            //If the player leaves the overlap sphere, continue patrolling
            if(!playerInSphere)
            {
                numTimesPressed = 0;
                sight.PlayerSeen = false;
                player.Seen = false;
                transform.LookAt(wayPoint);
            }
        }


        //Destroy if the monster spams enough
        if(sight.PlayerSeen && Input.GetButtonDown("Jump"))
        {
            numTimesPressed++;
            if (numTimesPressed >= 20)
            {
                player.Seen = false;
                audioSource.PlayOneShot(eatenSFX);
                numTimesPressed = 0;
                Destroy(this.gameObject);
            }
            else
            {
                audioSource.PlayOneShot(pressSFX);
            }
        }
    }

    private void SetDestination()
    {
        //Get nearest waypoints from waypoint objects
        Transform[] nearest = currentWaypoint.GetComponent<NearestWaypoints>().Nearest;
        int rand = Random.Range(0, nearest.Length);

        wayPoint = nearest[rand].position;
        currentWaypoint = nearest[rand];

        transform.LookAt(wayPoint);
    }

    public void SetDestination(Transform point)
    {
        wayPoint = point.position;
        currentWaypoint = point;
        transform.LookAt(wayPoint);
    }

}
