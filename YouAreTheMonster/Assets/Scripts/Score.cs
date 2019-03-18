using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private Image sightBar;
    [SerializeField]
    private int timeToLose;

    [SerializeField]
    private Transform[] spawns;
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject sightBarText;
    private MeshRenderer[] uiRenderers;
    private string startingText;

    private AudioSource audioSource;

    public bool Seen;
    private bool timer;

    public int ScoreCount { get; private set; }
    private bool nextToHouse;

    private House house;

    private void Awake()
    {
        ScoreCount = 0;
    }

    private void Start()
    {
        sightBarText.SetActive(false);
        startingText = scoreText.text;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Debug.Log("House: " + nextToHouse);
        if(Input.GetButtonDown("Submit") && nextToHouse && !house.Collected)
        {
            ScoreCount++;
            scoreText.text = startingText + ScoreCount;
            house.Collect();
            audioSource.Play();
            SpawnEnemy();
        }


        if (Seen)
        {
            if(sightBarText != null)
            {
                sightBarText.SetActive(true);
            }

            sightBar.fillAmount += (Time.deltaTime / timeToLose);

            if (sightBar.fillAmount >= 1)
            {
                Initiate.Fade("GameOver", Color.black, 2);
            }
        }

        if (!Seen)
        {
            if(sightBarText != null && sightBarText.activeInHierarchy)
            {
                Destroy(sightBarText, 5f);
            }
            timer = false;
            sightBar.fillAmount -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "House")
        {
            nextToHouse = true;
            house = other.GetComponent<House>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "House")
        {
            nextToHouse = false;
            house = null;
        }
    }

    private void SpawnEnemy()
    {
        switch(ScoreCount)
        {
           // case 2: case 4: case 6: case 8: case 10: case 12: case 14: case 16: case 18: case 20: case 22: case 24: case 25: case 26: case 28: case 30:
           //     Spawn();
           //     break;
            case 31:
                Initiate.Fade("Win", Color.black, 2);
                break;
        }
        Spawn();
    }

    private void Spawn()
    {
        int rand = Random.Range(0, spawns.Length - 1);
        GameObject newEnemy = Instantiate(enemy, spawns[rand]);
        newEnemy.GetComponent<Wander>().SetDestination(spawns[rand].GetComponent<NearestWaypoints>().Nearest[0]);
    }
}
