using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidoscontroller : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayShotDump()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }
}
