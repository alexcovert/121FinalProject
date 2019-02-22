using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public int SightDistance;

    public bool PlayerSeen;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, SightDistance))
        {
            //Debug.Log(hit.transform.tag);
            PlayerSeen = (hit.transform.tag == "Player");
        }
        if (Physics.Raycast(transform.position, (-transform.right + transform.forward).normalized, out hit, SightDistance))
        {
            PlayerSeen = (hit.transform.tag == "Player");
        }
        if (Physics.Raycast(transform.position, (transform.right + transform.forward).normalized, out hit, SightDistance))
        {
            //Debug.Log((transform.right + transform.forward) * SightDistance);
            PlayerSeen = (hit.transform.tag == "Player");
        }

        Debug.DrawRay(transform.position, transform.forward * SightDistance, Color.green);
        Debug.DrawRay(transform.position, (transform.right + transform.forward).normalized * SightDistance, Color.green);
        Debug.DrawRay(transform.position, (-transform.right + transform.forward).normalized * SightDistance, Color.green);

        Debug.Log(PlayerSeen);
    }
}

