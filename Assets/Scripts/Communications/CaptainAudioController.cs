using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaptainAudioController : MonoBehaviour
{
    [Header("Environment")]
    public bool treeAlertGiven;
    public bool waterAlertGiven;
    [SerializeField] private AudioClip[] treeAlerts;
    [SerializeField] private AudioClip[] waterAlerts;
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
    public SoldierMovement hellerUnit;
    private bool hellerdead;
    public SoldierMovement frazierUnit;
    private bool fradead;
    public SoldierMovement helprinUnit;
    private bool helprindead;
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
    public AudioSource captainVoice;

    [Header("Narrative")]
    [SerializeField] private AudioClip[] narrativeAudio;
    public int escapeAttempt = 0;
    private bool firstWarning;
    private bool secondWarning;
    private bool thirdWarning;
    private bool escapeLineOne;
    private bool escapeLineTwo;
    private bool escapeLineThree;
    public ExitGame exitGame;
    public TilemapCollider2D borders;
    public CircleCollider2D range;



    private void Start()
    {
        captainVoice.volume = 0f;
    }

    void Update()
    {
        if (!captainVoice.isPlaying)
        {
            SignalAlerts();
            InjuryAlerts();
            CombatAlerts();
            AllyDeathAlerts();
            MovingAlerts();
            TerrainAlerts();
        }

        NarrativeController();
    }

    void TerrainAlerts()
    {
        if(soldierMovement.touchWater && !waterAlertGiven)
        {
            int randomIndex = Random.Range(0, waterAlerts.Length);
            captainVoice.clip = waterAlerts[randomIndex];
            captainVoice.Play();
            waterAlertGiven = true;
        }

        if (soldierMovement.touchTrees && !treeAlertGiven)
        {
            int randomIndex = Random.Range(0, treeAlerts.Length);
            captainVoice.clip = treeAlerts[randomIndex];
            captainVoice.Play();
            treeAlertGiven = true;

        }

        if (soldierMovement.touchNeutralGround)
        {
            treeAlertGiven = false;
            waterAlertGiven = false;

        }
    }


    void SignalAlerts()
    {
        if (!signalLostAlertGiven && soldierMovement.soldierSignal < previousSignal)
        {
            Debug.Log("Signal Lost");
            int randomIndex = Random.Range(0, losingSignal.Length);
            captainVoice.clip = losingSignal[randomIndex];
            captainVoice.Play();
            signalLostAlertGiven = true;
            signalGainAlertGiven = true;
            ResetSignalAlert();
        }

        if (!signalGainAlertGiven && soldierMovement.soldierSignal > previousSignal)
        {
            int randomIndex = Random.Range(0, regainingSignal.Length);
            captainVoice.clip = regainingSignal[randomIndex];
            captainVoice.Play();
            signalGainAlertGiven = true;
            signalLostAlertGiven = true;
            ResetSignalAlert();
        }

        previousSignal = soldierMovement.soldierSignal;
    }

    IEnumerator ResetSignalAlert()
    {
        yield return new WaitForSeconds(15);
        signalLostAlertGiven = false;
        signalGainAlertGiven = true;

    }


    void InjuryAlerts()
    {
        if (!deathAlertGiven && soldierMovement.isDead)
        {
            int randomIndex = Random.Range(0, death.Length);
            captainVoice.clip = death[randomIndex];
            captainVoice.Play();
            deathAlertGiven = true;
        }

        if (soldierMovement.soldierHealth > 20f && soldierMovement.soldierHealth < 70f)
        {
            if (isListening)
            {
                int randomIndex = Random.Range(0, slightlyInjured.Length);
                captainVoice.clip = slightlyInjured[randomIndex];
                captainVoice.Play();
                injuredAlertGiven = true;
                InjuredAlert();

                if (soldierMovement.soldierSignal <= 1f)
                {
                    if (captainVoice != null)
                    {
                        captainVoice.volume = 0.5f;
                    }
                }

                if (soldierMovement.soldierSignal == 2f)
                {
                    if (captainVoice != null)
                    {
                        captainVoice.volume = 0.7f;
                    }
                }

                if (soldierMovement.soldierSignal >= 3f)
                {
                    if (captainVoice != null)
                    {   
                        captainVoice.volume = 1f;
                    }
                }
            }

            if (!isListening)
            {
                if (captainVoice != null)
                {
                    captainVoice.volume = 0f;
                }
            }

        }

        if (soldierMovement.soldierHealth <= 20f)
        {
            if (isListening)
            {
                int randomIndex = Random.Range(0, heavilyInjured.Length);
                captainVoice.clip = heavilyInjured[randomIndex];
                captainVoice.Play();
                injuredAlertGiven = true;
                InjuredAlert();

                if (soldierMovement.soldierSignal <= 1f)
                {
                    if (captainVoice != null)
                    {
                        captainVoice.volume = 0.5f;
                    }
                }

                if (soldierMovement.soldierSignal == 2f)
                {
                    if (captainVoice != null)
                    {
                        captainVoice.volume = 0.7f;
                    }
                }

                if (soldierMovement.soldierSignal >= 3f)
                {
                    if (captainVoice != null)
                    {
                        captainVoice.volume = 1f;
                    }
                }
            }

            if (!isListening)
            {
                if (captainVoice != null)
                {
                    captainVoice.volume = 0f;
                }
            }

        }

        if (soldierMovement.inCombat && !hitAlertGiven)
        {
            int randomIndex = Random.Range(0, hit.Length);
            captainVoice.clip = hit[randomIndex];
            captainVoice.Play();
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
                captainVoice.clip = enemyDown[randomIndex];
                captainVoice.Play();
                enemyDownAlertGiven = true;
            }


            if (!enemySpottedAlertGiven)
            {
                int randomIndex = Random.Range(0, enemySpotted.Length);
                captainVoice.clip = enemySpotted[randomIndex];
                captainVoice.Play();
                enemySpottedAlertGiven = true;
            }
        }

        if (soldierMovement.inCombat && !combatAlertGiven)
        {
            int randomIndex = Random.Range(0, combatStart.Length);
            captainVoice.clip = combatStart[randomIndex];
            captainVoice.Play();
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
        if (hellerUnit.soldierHealth <= 0 && !hellerdead)
        {
            captainVoice.clip = allyKilled[0];
            captainVoice.Play();
            hellerdead = true;
        }

        if (frazierUnit.soldierHealth <= 0 && !fradead)
        {
            captainVoice.clip = allyKilled[1];
            captainVoice.Play();
            fradead = true;
        }

        if (helprinUnit.soldierHealth <= 0 && !helprindead)
        {
            captainVoice.clip = allyKilled[2];
            captainVoice.Play();
            helprindead = true;
        }

        if (remarqueUnit.soldierHealth <= 0 && !remdead)
        {
            captainVoice.clip = allyKilled[3];
            captainVoice.Play();
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
                captainVoice.clip = advancing[randomIndex];
                captainVoice.Play();
                advanceAlertGiven = true;
                AdvanceAlert();
            }

            // If the soldier is moving away from the enemy and not too far, play retreating audio
            else if (Vector3.Dot(soldierMovement.transform.forward, soldierMovement.targetEnemy.transform.position - soldierMovement.transform.position) < 0f
                && distanceToEnemy < 10f)
            {
                int randomIndex = Random.Range(0, retreating.Length);
                captainVoice.clip = retreating[randomIndex];
                captainVoice.Play();
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == range && borders != null)
        {
            escapeAttempt = Mathf.Clamp(escapeAttempt + 1, 0, 6);
        }
    }

    public void NarrativeController()
    {
        if (escapeAttempt == 1)
        {
            if (firstWarning)
            {
                firstWarning = true;
                captainVoice.clip = narrativeAudio[0];
                captainVoice.Play();
            }
        }

        if (escapeAttempt == 2)
        {
            if (secondWarning)
            {
                secondWarning = true;
                captainVoice.clip = narrativeAudio[1];
                captainVoice.Play();
            }
        }

        if (escapeAttempt == 3)
        {
            if (!thirdWarning)
            {
                thirdWarning = true;
                captainVoice.clip = narrativeAudio[2];
                captainVoice.Play();
            }
        }

        if (escapeAttempt == 4)
        {
            if (!escapeLineOne)
            {
                escapeLineOne = true;
                captainVoice.clip = narrativeAudio[3];
                captainVoice.Play();
            }
        }

        if (escapeAttempt == 5)
        {
            if (!escapeLineTwo)
            {

                escapeLineTwo = true;
                captainVoice.clip = narrativeAudio[4];
                captainVoice.Play();
            }
        }

        if (escapeAttempt == 6)
        {
            if (!escapeLineThree)
            {
                escapeLineThree = true;
                captainVoice.clip = narrativeAudio[5];
                captainVoice.Play();
                Exit();
            }
            
        }
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(30);
        exitGame.ExittheGame();
    }
}
