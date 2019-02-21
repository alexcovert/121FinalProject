using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField]
    private int sightDistance;

    private RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, sightDistance))
        {
            if(hit.transform.tag == "Player")
            {
                Debug.Log("Sees Player");
            }
        }
    }

    private void DrawRay()
    {

    }
}

