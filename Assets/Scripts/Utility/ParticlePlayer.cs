﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary> Plays particle Fx </summary>
public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem[] allParticles;
    // Start is called before the first frame update
    void Start()
    {
        allParticles = GetComponentsInChildren<ParticleSystem>();
    }

    public void Play()
    {
        foreach(ParticleSystem ps in allParticles)
        {
            ps.Stop();
            ps.Play();
        }    
    }
}
