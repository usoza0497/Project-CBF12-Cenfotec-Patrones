using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private AudioSource audioSource;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
    }
    
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip) {
        audioSource.PlayOneShot(audioClip);
    }
}
