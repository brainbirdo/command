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

}
