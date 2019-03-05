using UnityEngine;

//https://answers.unity.com/questions/23010/ai-wandering-script.html
public class Wander : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int range;

    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private Transform currentWaypoint;

    private Vector3 wayPoint;

    private LineOfSight sight;

    void Start()
    {
        sight = GetComponent<LineOfSight>();

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
                sight.PlayerSeen = false;
                transform.LookAt(wayPoint);
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

}
