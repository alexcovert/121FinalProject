using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public int SightDistance;

    public bool PlayerSeen;

    private void Update()
    {
        Debug.Log(PlayerSeen);
        RaycastHit hit;

        Vector3 raycastFwd = transform.forward.normalized;
        Vector3 raycastRight = (transform.right + transform.forward).normalized;
        Vector3 raycastMidRight = (raycastRight + transform.forward).normalized;
        Vector3 raycastLeft = (-transform.right + transform.forward).normalized;
        Vector3 raycastMidLeft = (raycastLeft + transform.forward).normalized;

        if (checkRays(raycastFwd, out hit))
        {
            if(hit.transform.tag == "Player")
            {
                PlayerSeen = true;
            }
        }
        if (checkRays(raycastLeft, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
            }
        }
        if (checkRays(raycastRight, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
            }
        }
        if (checkRays(raycastMidRight, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
            }
        }
        if (checkRays(raycastMidLeft, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
            }
        }


        //Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), raycastFwd * SightDistance, Color.green);
        //Debug.DrawRay(transform.position, raycastRight * SightDistance, Color.green);
        //Debug.DrawRay(transform.position, raycastLeft * SightDistance, Color.green);
        //Debug.DrawRay(transform.position, raycastMidRight * SightDistance, Color.red);
        //Debug.DrawRay(transform.position, raycastMidLeft * SightDistance, Color.red);

        //Debug.Log("PlayerSeen: " + PlayerSeen);
    }

    private bool checkRays(Vector3 rayToCheck, out RaycastHit hit)
    {
        return Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), rayToCheck, out hit, SightDistance);
    }
}

