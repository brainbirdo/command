using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelprinAudioController : MonoBehaviour
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
    public SoldierMovement hellerUnit;
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
    public AudioSource helprinVoice;


    private void Start()
    {
        helprinVoice.volume = 0f;
    }

    void Update()
    {
        if (!helprinVoice.isPlaying)
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
            helprinVoice.clip = rainAlerts[randomIndex];
            helprinVoice.Play();

            // Set the rain alert given flag to true
            rainAlertGiven = true;
        }

        if (!stormAlertGiven && weatherController.isStormy)
        {
            int randomIndex = Random.Range(0, stormAlerts.Length);
            helprinVoice.clip = stormAlerts[randomIndex];
            helprinVoice.Play();
            // Set the rain alert given flag to true
            stormAlertGiven = true;
        }
    }

    void SignalAlerts()
    {
        if (!signalLostAlertGiven && soldierMovement.soldierSignal < previousSignal)
        {
            int randomIndex = Random.Range(0, losingSignal.Length);
            helprinVoice.clip = losingSignal[randomIndex];
            helprinVoice.Play();
            signalLostAlertGiven = true;
            signalGainAlertGiven = false;
            ResetSignalLostAlert();
        }

        if (!signalGainAlertGiven && soldierMovement.soldierSignal > previousSignal)
        {
            int randomIndex = Random.Range(0, regainingSignal.Length);
            helprinVoice.clip = regainingSignal[randomIndex];
            helprinVoice.Play();
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
            helprinVoice.clip = death[randomIndex];
            helprinVoice.Play();
            deathAlertGiven = true;
        }

        if (soldierMovement.soldierHealth > 20f && soldierMovement.soldierHealth < 70f)
        {
            if (isListening)
            {
                int randomIndex = Random.Range(0, slightlyInjured.Length);
                helprinVoice.clip = slightlyInjured[randomIndex];
                helprinVoice.Play();
                injuredAlertGiven = true;
                InjuredAlert();

                if (soldierMovement.soldierSignal <= 1f)
                {
                    if (helprinVoice != null)
                    {
                        helprinVoice.volume = 0.5f;
                    }
                }

                if (soldierMovement.soldierSignal == 2f)
                {
                    if (helprinVoice != null)
                    {
                        helprinVoice.volume = 0.7f;
                    }
                }

                if (soldierMovement.soldierSignal >= 3f)
                {
                    if (helprinVoice != null)
                    {
                        helprinVoice.volume = 1f;
                    }
                }
            }

            if (!isListening)
            {
                if (helprinVoice != null)
                {
                    helprinVoice.volume = 0f;
                }
            }

        }

        if (soldierMovement.soldierHealth <= 20f)
        {
            if (isListening)
            {
                int randomIndex = Random.Range(0, heavilyInjured.Length);
                helprinVoice.clip = heavilyInjured[randomIndex];
                helprinVoice.Play();
                injuredAlertGiven = true;
                InjuredAlert();

                if (soldierMovement.soldierSignal <= 1f)
                {
                    if (helprinVoice != null)
                    {
                        helprinVoice.volume = 0.5f;
                    }
                }

                if (soldierMovement.soldierSignal == 2f)
                {
                    if (helprinVoice != null)
                    {
                        helprinVoice.volume = 0.7f;
                    }
                }

                if (soldierMovement.soldierSignal >= 3f)
                {
                    if (helprinVoice != null)
                    {
                        helprinVoice.volume = 1f;
                    }
                }
            }

            if (!isListening)
            {
                if (helprinVoice != null)
                {
                    helprinVoice.volume = 0f;
                }
            }

        }

        if (soldierMovement.inCombat && !hitAlertGiven)
        {
            int randomIndex = Random.Range(0, hit.Length);
            helprinVoice.clip = hit[randomIndex];
            helprinVoice.Play();
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
        if (soldierMovement.targetEnemy != null)
        {
            Enemy enemy = soldierMovement.targetEnemy.GetComponent<Enemy>();

            if (enemy.enemyHealth < 1)
            {
                int randomIndex = Random.Range(0, enemyDown.Length);
                helprinVoice.clip = enemyDown[randomIndex];
                helprinVoice.Play();
                enemyDownAlertGiven = true;
            }

            if (!enemySpottedAlertGiven)
            {
                int randomIndex = Random.Range(0, enemySpotted.Length);
                helprinVoice.clip = enemySpotted[randomIndex];
                helprinVoice.Play();
                enemySpottedAlertGiven = true;
            }
        }

        if (soldierMovement.inCombat && !combatAlertGiven)
        {
            int randomIndex = Random.Range(0, combatStart.Length);
            helprinVoice.clip = combatStart[randomIndex];
            helprinVoice.Play();
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
        if (captainUnit.soldierHealth <= 0 && !capdead)
        {
            helprinVoice.clip = allyKilled[0];
            helprinVoice.Play();
            capdead = true;
        }

        if (frazierUnit.soldierHealth <= 0 && !fradead)
        {
            helprinVoice.clip = allyKilled[1];
            helprinVoice.Play();
            fradead = true;
        }

        if (hellerUnit.soldierHealth <= 0 && !heldead)
        {
            helprinVoice.clip = allyKilled[2];
            helprinVoice.Play();
            heldead = true;
        }

        if (remarqueUnit.soldierHealth <= 0 && !remdead)
        {
            helprinVoice.clip = allyKilled[3];
            helprinVoice.Play();
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
                helprinVoice.clip = advancing[randomIndex];
                helprinVoice.Play();
                advanceAlertGiven = true;
                AdvanceAlert();
            }

            // If the soldier is moving away from the enemy and not too far, play retreating audio
            else if (Vector3.Dot(soldierMovement.transform.forward, soldierMovement.targetEnemy.transform.position - soldierMovement.transform.position) < 0f
                && distanceToEnemy < 10f)
            {
                int randomIndex = Random.Range(0, retreating.Length);
                helprinVoice.clip = retreating[randomIndex];
                helprinVoice.Play();
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
