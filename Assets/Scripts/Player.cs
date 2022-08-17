using Assembly_CSharp;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Platform CurrentPlatform;
    public Game Game;
    public int playerScore;
    private AudioSource _bounsesound;
    public AudioClip platformDestroySound;
    public float VictoryVolume;
    public float DestroyVolume;
    public float LoseVolume;
    

    private void Start()
    {
        playerScore = 0;
        _bounsesound = GetComponent<AudioSource>();
    }

    void addPoints(int points)
    {
        playerScore += points;
    }

    void PlayDestroySound(AudioSource PlatformDestroySound)
    {
        _bounsesound.PlayOneShot(platformDestroySound, DestroyVolume);
    }

    void PlayVictorySound(AudioClip VictorySound)
    {
        _bounsesound.PlayOneShot(VictorySound, VictoryVolume);
    }

    void PlayLoseSound(AudioClip LoseSound)
    {
        _bounsesound.PlayOneShot(LoseSound, LoseVolume);
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        _bounsesound.Play();
    }



    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.one;
        

    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }
}
