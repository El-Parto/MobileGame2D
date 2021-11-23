using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using Random = System.Random;

public class Bricked : MonoBehaviour
{
    private GuiManager guiM;

    [SerializeField] private AudioSource onHitSound;
    [SerializeField] private AudioSource[] hitSounds;
    [SerializeField] private AudioMixerGroup audio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        guiM = FindObjectOfType<GuiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    ///<summary>
    ///When the object is destroyed, use a randomised number to determin what sound is played
    /// and what pitch it should be played at.
    /// </summary>
     
    public void OnDestroy()
    {
        int index = UnityEngine.Random.Range(0, 3);
        float randPitch = UnityEngine.Random.Range(0.7f, 2);
        onHitSound = hitSounds[index];
        audio.audioMixer.SetFloat("SFX_Pitch", randPitch);
        onHitSound.Play();
        
        guiM.score--;
        
    }
}
