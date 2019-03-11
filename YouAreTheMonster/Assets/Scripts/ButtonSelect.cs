using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hoverSFX;

    public void PlayHoverSFX()
    {
        audioSource.PlayOneShot(hoverSFX);
    }
}
