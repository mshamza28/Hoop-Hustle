using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource bounceAudioSource;
    public AudioClip bounceSound;
    // Start is called before the first frame update
    void Start()
    {
        bounceAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the ball collided with is the ground
        if (collision.gameObject.CompareTag("Backboard"))
        {
            bounceAudioSource.PlayOneShot(bounceSound, 0.1f);

        }
    }
}
