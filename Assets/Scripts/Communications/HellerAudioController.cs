using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellerAudioController : MonoBehaviour
{
    [Header("Environment")]
    [SerializeField] private AudioClip[] rainAlerts;
    [SerializeField] private AudioClip[] stormAlerts;

    [Header("Statistics")]
    [SerializeField] private AudioClip[] losingSignal;
    [SerializeField] private AudioClip[] regainingSignal;
    [SerializeField] private AudioClip[] slightlyInjured;
    [SerializeField] private AudioClip[] heavilyInjured;
    [SerializeField] private AudioClip[] death;
    [SerializeField] private AudioClip[] hit;

    [Header("Combat")]
    [SerializeField] private AudioClip[] enemySpotted;
    [SerializeField] private AudioClip[] enemyDown;
    [SerializeField] private AudioClip[] allyKilled;
    [SerializeField] private AudioClip[] advancing;
    [SerializeField] private AudioClip[] retreating;
    [SerializeField] private AudioClip[] combatStart;
    [SerializeField] private AudioClip[] idle;

    [Header("Comms Switching")]
    public bool isListening;
    public SoldierMovement soldierMovement;

    [Header("Audio Sources: Ambience")]
    public AudioSource noSignal;
    public AudioSource badSignal;
    public AudioSource goodSignal;

    void Update()
    {
        StaticSoundUpdate();
    }

    void StaticSoundUpdate()
    {
        if (isListening)
        {
            if (soldierMovement.soldierSignal <= 1f)
            {
                noSignal.volume = 0.7f;
            }

            if (soldierMovement.soldierSignal == 2f)
            {
                badSignal.volume = 0.7f;
            }

            if (soldierMovement.soldierSignal >= 3f)
            {
                goodSignal.volume = 0.7f;
            }
        }

        if (!isListening)
        {
            noSignal.volume = 0f;
            badSignal.volume = 0f;
            goodSignal.volume = 0f;
        }
    }
}
