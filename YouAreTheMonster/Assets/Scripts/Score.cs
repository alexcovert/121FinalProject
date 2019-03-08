using UnityEngine;
using UnityEngine.UI;
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

    private string startingText;

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
        startingText = scoreText.text;
    }

    private void Update()
    {
        //Debug.Log("House: " + nextToHouse);
        if(Input.GetButtonDown("Submit") && nextToHouse && !house.Collected)
        {
            ScoreCount++;
            scoreText.text = startingText + ScoreCount;
            house.Collect();

            SpawnEnemy();
        }


        if (Seen)
        {
            sightBar.fillAmount += (Time.deltaTime / timeToLose);

            if (sightBar.fillAmount >= 1)
            {
                //   Debug.Log("Game Over");
                Initiate.Fade("GameOver", Color.black, 2);
            }
        }

        if (!Seen)
        {
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
            case 2: case 4: case 6: case 8: case 10: case 12: case 14: case 16: case 18: case 20: case 22: case 24: case 25: case 26: case 28: case 30:
                Spawn();
                break;
        }
    }

    private void Spawn()
    {
        int rand = Random.Range(0, spawns.Length - 1);
        GameObject newEnemy = Instantiate(enemy, spawns[rand]);
        newEnemy.GetComponent<Wander>().SetDestination(spawns[rand].GetComponent<NearestWaypoints>().Nearest[0]);
    }
}
