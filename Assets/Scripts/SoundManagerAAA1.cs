using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerAAA1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winStone, Jump, walk, enemy, traps;

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
    public void PlayJump()
    {
        audioSource.PlayOneShot(Jump);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winStone);
    }

    public void PlayWalk()
    {
        audioSource.PlayOneShot(walk);
        
    }

    public void Playenemy()
    {
        audioSource.PlayOneShot(enemy);
    }

    public void Playtraps()
    {
        audioSource.PlayOneShot(traps);
    }



}
