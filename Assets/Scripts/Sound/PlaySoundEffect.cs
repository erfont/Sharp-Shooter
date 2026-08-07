using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Plays a single sound effect from an AudioClip assigned in the Inspector.
/// Attach this to any GameObject, assign an AudioSource and AudioClip, and
/// call PlaySFX() from anywhere (a button, a collision, another script, etc.).
/// </summary>
/// 

public class PlaySoundEffect : MonoBehaviour
{
    [Tooltip("The sound effect clip to play. Drag an audio file from your Assets folder here.")]
    [SerializeField] public AudioClip sfxClip;
 
    [Tooltip("Volume of the sound effect (0 = silent, 1 = full volume).")]
    [Range(0f, 1f)]
    [SerializeField] public float volume = 1f;
 
    [Tooltip("If true, the sound effect plays automatically when this object starts.")]
    [SerializeField] public bool playOnStart = false;
 
    AudioSource audioSource;
 
    private void Awake()
    {
        // Make sure this AudioSource doesn't auto-play the clip on its own;
        // we trigger playback manually via PlaySFX().
    }
 
    private void Start()
    {
        if (playOnStart)
        {
            PlaySFX();
        }
    }
 
    /// <summary>
    /// Plays the assigned sound effect once.
    /// Uses PlayOneShot so overlapping calls won't cut each other off.
    /// </summary>
    public void PlaySFX()
    {
        if (sfxClip == null)
        {
            Debug.LogWarning($"[{nameof(PlaySoundEffect)}] No AudioClip assigned on {gameObject.name}.");
            return;
        }
 
        audioSource.PlayOneShot(sfxClip, volume);
    }

    public void SetAudioSource(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }
 
    // Optional: trigger the sound effect when this object collides with something.
    // Remove this method if you don't need collision-based playback.
    // private void OnCollisionEnter(Collision collision)
    // {
    //     PlaySFX();
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     PlaySFX();
    // }
}