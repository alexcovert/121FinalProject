using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private string startingText;

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
}
