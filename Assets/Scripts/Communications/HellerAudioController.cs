using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellerAudioController : MonoBehaviour
{
    [Header("Environment")]
    public bool rainAlertGiven;
    public bool stormAlertGiven;
    [SerializeField] private AudioClip[] rainAlerts;
    [SerializeField] private AudioClip[] stormAlerts;
    public WeatherController weatherController;

    [Header("Statistics")]
    public float previousSignal;
    public bool signalLostAlertGiven;
    public bool signalGainAlertGiven;
    [SerializeField] private AudioClip[] losingSignal;
    [SerializeField] private AudioClip[] regainingSignal;

    public bool injuredAlertGiven;
    [SerializeField] private AudioClip[] slightlyInjured;
    [SerializeField] private AudioClip[] heavilyInjured;

    public bool deathAlertGiven;
    public bool hitAlertGiven;
    [SerializeField] private AudioClip[] death;
    [SerializeField] private AudioClip[] hit;

    [Header("Combat")]
    private bool enemySpottedAlertGiven;
    [SerializeField] private AudioClip[] enemySpotted;
    public bool enemyDownAlertGiven;
    [SerializeField] private AudioClip[] enemyDown;

    [Header("Squad")]
    public SoldierMovement captainUnit;
    private bool capdead;
    public SoldierMovement frazierUnit;
    private bool fradead;
    public SoldierMovement helprinUnit;
    private bool heldead;
    public SoldierMovement remarqueUnit;
    private bool remdead;
    [SerializeField] private AudioClip[] allyKilled;

    public bool advanceAlertGiven;
    public bool retreatAlertGiven;
    [SerializeField] private AudioClip[] advancing;
    [SerializeField] private AudioClip[] retreating; 
    public bool combatAlertGiven;
    [SerializeField] private AudioClip[] combatStart;
    [SerializeField] private AudioClip[] idle;

    [Header("Comms Switching")]
    public bool isListening;
    public SoldierMovement soldierMovement;
    public AudioSource hellerVoice;


    private void Start()
    {
        hellerVoice.volume = 0f;
    }

    void Update()
    {
        if (!hellerVoice.isPlaying)
        {
            EnvironmentSoundAlerts();
            SignalAlerts();
            InjuryAlerts();
            CombatAlerts();
            AllyDeathAlerts();
            MovingAlerts();
        }
    }


    void EnvironmentSoundAlerts()
    {
        if (!rainAlertGiven && weatherController.isRainy)
        {
            // Play a random rain alert clip
            int randomIndex = Random.Range(0, rainAlerts.Length);
            hellerVoice.clip = rainAlerts[randomIndex];
            hellerVoice.Play();

            // Set the rain alert given flag to true
            rainAlertGiven = true;
        }

        if (!stormAlertGiven && weatherController.isStormy)
        {
            int randomIndex = Random.Range(0, stormAlerts.Length);
            hellerVoice.clip = stormAlerts[randomIndex];
            hellerVoice.Play();
            // Set the rain alert given flag to true
            stormAlertGiven = true;
        }
    }

    void SignalAlerts()
    {
        if (!signalLostAlertGiven && soldierMovement.soldierSignal < previousSignal)
        {
            int randomIndex = Random.Range(0, losingSignal.Length);
            hellerVoice.clip = losingSignal[randomIndex];
            hellerVoice.Play();
            signalLostAlertGiven = true;
            signalGainAlertGiven = false;
            ResetSignalLostAlert();
        }

        if (!signalGainAlertGiven && soldierMovement.soldierSignal > previousSignal)
        {
            int randomIndex = Random.Range(0, regainingSignal.Length);
            hellerVoice.clip = regainingSignal[randomIndex];
            hellerVoice.Play();
            signalGainAlertGiven = true;
            signalLostAlertGiven = false;
            ResetSignalGainAlert();
        }

        previousSignal = soldierMovement.soldierSignal;
    }

    IEnumerator ResetSignalLostAlert()
    {
        yield return new WaitForSeconds(10);
        signalLostAlertGiven = false;
    }

    IEnumerator ResetSignalGainAlert()
    {
        yield return new WaitForSeconds(10);
        signalGainAlertGiven = false;
    }

    void InjuryAlerts()
    {
        if (!deathAlertGiven && soldierMovement.isDead)
        {
            int randomIndex = Random.Range(0, death.Length);
            hellerVoice.clip = death[randomIndex];
            hellerVoice.Play();
            deathAlertGiven = true;
        }

        if (soldierMovement.soldierHealth >20f && soldierMovement.soldierHealth < 70f)
        {
            if (isListening)
            {
                int randomIndex = Random.Range(0, slightlyInjured.Length);
                hellerVoice.clip = slightlyInjured[randomIndex];
                hellerVoice.Play();
                injuredAlertGiven = true;
                InjuredAlert();

                if (soldierMovement.soldierSignal <= 1f)
                {
                    if (hellerVoice != null)
                    {
                        hellerVoice.volume = 0.5f;
                    }
                }

                if (soldierMovement.soldierSignal == 2f)
                {
                    if (hellerVoice != null)
                    {
                        hellerVoice.volume = 0.7f;
                    }
                }

                if (soldierMovement.soldierSignal >= 3f)
                {
                    if (hellerVoice != null)
                    {
                        hellerVoice.volume = 1f;
                    }
                }
            }

            if (!isListening)
            {
                if (hellerVoice != null)
                {
                    hellerVoice.volume = 0f;
                }
            }
            
        }

        if (soldierMovement.soldierHealth <=20f)
        {
            if (isListening)
            {
                int randomIndex = Random.Range(0, heavilyInjured.Length);
                hellerVoice.clip = heavilyInjured[randomIndex];
                hellerVoice.Play();
                injuredAlertGiven = true;
                InjuredAlert();

                if (soldierMovement.soldierSignal <= 1f)
                {
                    if (hellerVoice != null)
                    {
                        hellerVoice.volume = 0.5f;
                    }
                }

                if (soldierMovement.soldierSignal == 2f)
                {
                    if (hellerVoice != null)
                    {
                        hellerVoice.volume = 0.7f;
                    }
                }

                if (soldierMovement.soldierSignal >= 3f)
                {
                    if (hellerVoice != null)
                    {
                        hellerVoice.volume = 1f;
                    }
                }
            }

            if (!isListening)
            {
                if (hellerVoice != null)
                {
                    hellerVoice.volume = 0f;
                }
            }

        }

        if (soldierMovement.inCombat && !hitAlertGiven)
        {
            int randomIndex = Random.Range(0, hit.Length);
            hellerVoice.clip = hit[randomIndex];
            hellerVoice.Play();
            hitAlertGiven = true;
            HitAlert();
        }
    }

    IEnumerator InjuredAlert()
    {
        yield return new WaitForSeconds(10);
        injuredAlertGiven = false;
    }

    IEnumerator HitAlert()
    {
        yield return new WaitForSeconds(10);
        hitAlertGiven = false;
    }

    void CombatAlerts()
    {
        if(soldierMovement.targetEnemy != null)
        {
            Enemy enemy = soldierMovement.targetEnemy.GetComponent<Enemy>();

            if (enemy.enemyHealth < 1)
            {
                int randomIndex = Random.Range(0, enemyDown.Length);
                hellerVoice.clip = enemyDown[randomIndex];
                hellerVoice.Play();
                enemyDownAlertGiven = true;
            }


            if (!enemySpottedAlertGiven)
            {
                int randomIndex = Random.Range(0, enemySpotted.Length);
                hellerVoice.clip = enemySpotted[randomIndex];
                hellerVoice.Play();
                enemySpottedAlertGiven = true;
            }
        }

        if (soldierMovement.inCombat && !combatAlertGiven)
        {
            int randomIndex = Random.Range(0, combatStart.Length);
            hellerVoice.clip = combatStart[randomIndex];
            hellerVoice.Play();
            combatAlertGiven = true;
        }


        if (soldierMovement.targetEnemy = null)
        {
            enemySpottedAlertGiven = false;
            enemyDownAlertGiven = false;
        }



    }

    void AllyDeathAlerts()
    {
        if(captainUnit.soldierHealth <= 0 && !capdead)
        {
            hellerVoice.clip = allyKilled[0];
            hellerVoice.Play();
            capdead = true;
        }

        if (frazierUnit.soldierHealth <= 0 && !fradead)
        {
            hellerVoice.clip = allyKilled[1];
            hellerVoice.Play();
            fradead = true;
        }

        if (helprinUnit.soldierHealth <= 0 && !heldead)
        {
            hellerVoice.clip = allyKilled[2];
            hellerVoice.Play();
            heldead = true;
        }

        if (remarqueUnit.soldierHealth <= 0 && !remdead)
        {
            hellerVoice.clip = allyKilled[3];
            hellerVoice.Play();
            remdead = true;
        }
    }

    void MovingAlerts()
    {
        if (soldierMovement.hasTarget && soldierMovement.targetEnemy != null)
        {
            // Calculate distance to the enemy
            float distanceToEnemy = Vector3.Distance(soldierMovement.transform.position, soldierMovement.targetEnemy.transform.position);

            // If the soldier is moving towards the enemy and not too close, play advancing audio
            if (Vector3.Dot(soldierMovement.transform.forward, soldierMovement.targetEnemy.transform.position - soldierMovement.transform.position) > 0f
                && distanceToEnemy > 5f)
            {
                int randomIndex = Random.Range(0, advancing.Length);
                hellerVoice.clip = advancing[randomIndex];
                hellerVoice.Play();
                advanceAlertGiven = true;
                AdvanceAlert();
            }

            // If the soldier is moving away from the enemy and not too far, play retreating audio
            else if (Vector3.Dot(soldierMovement.transform.forward, soldierMovement.targetEnemy.transform.position - soldierMovement.transform.position) < 0f
                && distanceToEnemy < 10f)
            {
                int randomIndex = Random.Range(0, retreating.Length);
                hellerVoice.clip = retreating[randomIndex];
                hellerVoice.Play();
                retreatAlertGiven = true;
                RetreatAlert();
            }
        }
    }

    IEnumerator AdvanceAlert()
    {
        yield return new WaitForSeconds(10);
        advanceAlertGiven = false;
    }
    IEnumerator RetreatAlert()
    {
        yield return new WaitForSeconds(10);
        retreatAlertGiven = false;
    }


}
