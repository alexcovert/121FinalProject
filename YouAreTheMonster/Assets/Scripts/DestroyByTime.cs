using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5f);   
    }
}
