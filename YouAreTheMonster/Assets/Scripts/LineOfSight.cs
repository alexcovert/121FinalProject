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
            Debug.Log("raycasthit");
            Debug.Log(hit.transform.tag);
            PlayerSeen = (hit.transform.tag == "Player");
        }
    }
}

