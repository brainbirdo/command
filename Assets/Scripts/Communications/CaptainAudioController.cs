using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainAudioController : MonoBehaviour
{
    [Header("Environment")]
    [SerializeField] private AudioClip[] treeAlerts;
    [SerializeField] private AudioClip[] waterAlerts;
    [SerializeField] private AudioClip[] obstacleAlerts;
    [SerializeField] private AudioClip[] arrivedAtDestination;
    [SerializeField] private AudioClip[] orderReceived;

    [Header("Statistics")]
    [SerializeField] private AudioClip[] commsOnline;
    [SerializeField] private AudioClip[] losingSignal;
    [SerializeField] private AudioClip[] regainingSignal;
    [SerializeField] private AudioClip[] slightlyInjured;
    [SerializeField] private AudioClip[] heavilyInjured;
    [SerializeField] private AudioClip[] death;
    [SerializeField] private AudioClip[] hit;

    [Header("Combat")]
    [SerializeField] private AudioClip[] enemySpotted;
    [SerializeField] private AudioClip[] seenByEnemy;
    [SerializeField] private AudioClip[] allyKilled;
    [SerializeField] private AudioClip[] advancing;
    [SerializeField] private AudioClip[] retreating;
    [SerializeField] private AudioClip[] combatStart;
    [SerializeField] private AudioClip[] enemyLow;
    [SerializeField] private AudioClip[] idle;

    [Header("Combat")]
    [SerializeField] private AudioClip[] dialogue;

    [Header("Comms Switching")]
    public bool isListening;

}
