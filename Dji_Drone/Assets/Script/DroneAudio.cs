using UnityEngine;

public class DroneAudio : MonoBehaviour
{
    public static DroneAudio instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }else
        {
            Destroy(instance);
        }
    }
    public enum DroneState { Off, On, Fly }
    public DroneState currentState = DroneState.Off;

    public AudioClip engineOnClip;
    public AudioClip engineOffClip;
    public AudioClip flyingClip;

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Example state change logic (replace with your actual implementation)
        if (Input.GetKeyDown(KeyCode.O)) SetState(DroneState.On);
        if (Input.GetKeyDown(KeyCode.F)) SetState(DroneState.Fly);
        if (Input.GetKeyDown(KeyCode.P)) SetState(DroneState.Off);
    }

    public void SetState(DroneState newState)
    {
        currentState = newState;
        PlayAudioForState(newState);
    }

    private void PlayAudioForState(DroneState state)
    {
        switch (state)
        {
            case DroneState.Off:
                PlayAudio(engineOffClip);
                break;
            case DroneState.On:
                PlayAudio(engineOnClip);
                break;
            case DroneState.Fly:
                PlayAudio(flyingClip, true); // Loop the flying sound
                break;
        }
    }

    private void PlayAudio(AudioClip clip, bool loop = false)
    {
        if (clip == null || audioSource == null)
            return;

        audioSource.loop = loop;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
