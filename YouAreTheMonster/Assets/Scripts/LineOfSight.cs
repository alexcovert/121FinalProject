using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] private int timeToLose;
    private Image sightBar;
    public int SightDistance;

    public bool PlayerSeen;


    public bool timer = false;

    private void Start()
    {
        sightBar = GameObject.Find("FillImage").GetComponent<Image>();
    }
    private void Update()
    {
        RaycastHit hit;

        Vector3 raycastFwd = transform.forward.normalized;
        Vector3 raycastRight = (transform.right + transform.forward).normalized;
        Vector3 raycastMidRight = (raycastRight + transform.forward).normalized;
        Vector3 raycastLeft = (-transform.right + transform.forward).normalized;
        Vector3 raycastMidLeft = (raycastLeft + transform.forward).normalized;

        if (checkRays(raycastFwd, out hit) && !timer)
        {
            if(hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastLeft, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastRight, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastMidRight, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastMidLeft, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        
        //if(PlayerSeen && timer)
        //{
        //    Debug.Log("Hello?");
        //    Debug.Log(sightBar.fillAmount);
        //    sightBar.fillAmount += (Time.deltaTime / timeToLose);

        //    if(sightBar.fillAmount >= 1)
        //    {
        //        //   Debug.Log("Game Over");
        //        Initiate.Fade("GameOver", Color.black, 2);
        //    }
        //}

        //if(!PlayerSeen)
        //{
        //    timer = false;
        //    sightBar.fillAmount -= Time.deltaTime;
        //}

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

    //private IEnumerator LoseTimer()
    //{
    //    yield return new WaitForSeconds(1);
    //    timePassed++;
    //    sightBar.fillAmount = (float)timePassed / (float)timeToLose;
    //    Debug.Log(sightBar.fillAmount);

    //    if (timePassed >= timeToLose)
    //    {
    //        timePassed = 0;
    //        timer = null;
    //    }
    //    else
    //    {
    //        timer = StartCoroutine(LoseTimer());
    //    }
    //}
}

