using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKey : MonoBehaviour
{
    private bool ready = false;
    [SerializeField] private GameObject anyKeyText;

    void Start()
    {
        anyKeyText.SetActive(false);
        StartCoroutine(Wait());
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && ready)
        {
            Initiate.Fade("Game", Color.black, 2);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        ready = true;
        anyKeyText.SetActive(true);
    }

}
