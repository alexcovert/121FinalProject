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

    private AudioSource audioSource;
    [SerializeField] private AudioClip seenSFX;
    [SerializeField] private AudioClip notSeenSFX;
    private bool playSeen = true;
    private bool playNotSeen = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                if (playSeen)
                {
                    audioSource.PlayOneShot(seenSFX);
                    playSeen = false;
                }
                playNotSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastLeft, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                if (playSeen)
                {
                    audioSource.PlayOneShot(seenSFX);
                    playSeen = false;
                }
                playNotSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastRight, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                if (playSeen)
                {
                    audioSource.PlayOneShot(seenSFX);
                    playSeen = false;
                }
                playNotSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastMidRight, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                if (playSeen)
                {
                    audioSource.PlayOneShot(seenSFX);
                    playSeen = false;
                }
                playNotSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        if (checkRays(raycastMidLeft, out hit) && !timer)
        {
            if (hit.transform.tag == "Player")
            {
                PlayerSeen = true;
                if (playSeen)
                {
                    audioSource.PlayOneShot(seenSFX);
                    playSeen = false;
                }
                playNotSeen = true;
                hit.transform.GetComponent<Score>().Seen = true;
            }
        }
        
        if(!PlayerSeen && playNotSeen)
        {
            audioSource.PlayOneShot(notSeenSFX);
            playNotSeen = false;
            playSeen = true;
        }
    
        //Debug.Log("PlayerSeen: " + PlayerSeen);
    }

    private bool checkRays(Vector3 rayToCheck, out RaycastHit hit)
    {
        return Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), rayToCheck, out hit, SightDistance);
    }


}

