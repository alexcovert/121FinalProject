using UnityEngine;

//https://www.reddit.com/r/Unity3D/comments/95ln3r/help_isometric_camera_and_movement/
[RequireComponent(typeof(Rigidbody))]
public class CharacterControllerISO : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    private Rigidbody rb;

    Vector3 forward, right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }


    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.25f || Mathf.Abs(Input.GetAxis("Vertical")) >= 0.25f)
        {
            Move();
        }
    }

    void Move()
    {
        ////Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));

        Vector3 rightMovement = right * Input.GetAxis("Horizontal");
        Vector3 forwardMovement = forward * Input.GetAxis("Vertical");

        Vector3 direction = Vector3.Normalize(rightMovement + forwardMovement);
        transform.forward = -direction;

        rb.velocity = direction * moveSpeed;
        Debug.Log(rb.velocity);

        //transform.forward = -heading;
        //transform.position += heading * moveSpeed * Time.deltaTime;//+= rightMovement;
        ////transform.position += upMovement;
    }
}
