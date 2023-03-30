using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsSwitcher : MonoBehaviour
{
    public bool isListening;

    public CaptainAudioController captainAudioController;
    public SoldierMovement captainMovement;
    public AudioSource captainVoice;


    public HellerAudioController hellerAudioController;
    public SoldierMovement hellerMovement;
    public AudioSource hellerVoice;


    public HelprinAudioController helprinAudioController;
    public SoldierMovement helprinMovement;
    public AudioSource helprinVoice;

    public AudioSource noSignal;
    public AudioSource badSignal;
    public AudioSource goodSignal;
    public AudioSource gunfire;
    public AudioSource combatAudio;
    public AudioSource heartbeat;
    public AudioSource rain;
    public AudioSource storm;

    void Update()
    {
        Voice001();
        Voice002();
        Voice004();
        StaticSoundUpdate();

        if (!isListening)
        {
            rain.volume = 0.0f;
            storm.volume = 0.0f;
            gunfire.volume = 0.0f;
            combatAudio.volume = 0.0f;
        }
    }


    void Start()
    {
        noSignal.volume = 0.0f;
        badSignal.volume = 0.0f;
        goodSignal.volume = 0.0f;
        gunfire.volume = 0.0f;
        combatAudio.volume = 0.0f;
        heartbeat.volume = 0.7f;
        captainVoice.volume = 0.0f;
        hellerVoice.volume = 0.0f;
        helprinVoice.volume = 0.0f;
        rain.volume = 0.0f;
        storm.volume = 0.0f;
    }

    void StaticSoundUpdate()
    {
        if (isListening && hellerAudioController.isListening)
        {
            if (hellerMovement.soldierSignal <= 1f)
            {
                hellerVoice.volume = 0.2f;
                noSignal.volume = 0.7f;
                badSignal.volume = 0.0f;
                goodSignal.volume = 0.0f;

                if (hellerMovement.inCombat)
                {
                    gunfire.volume = 0.2f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!hellerMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }

            if (hellerMovement.soldierSignal == 2f)
            {
                hellerVoice.volume = 0.5f;
                badSignal.volume = 0.7f;
                noSignal.volume = 0.0f;
                goodSignal.volume = 0.0f;

                if (hellerMovement.inCombat)
                {
                    gunfire.volume = 0.3f;
                    combatAudio.volume = 0.1f;
                }
                if (!hellerMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }

            if (hellerMovement.soldierSignal >= 3f)
            {
                hellerVoice.volume = 0.8f;
                goodSignal.volume = 0.7f;
                noSignal.volume = 0.0f;
                badSignal.volume = 0.0f;
                if (hellerMovement.inCombat)
                {
                    gunfire.volume = 0.4f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!hellerMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }
        }

        if (isListening && helprinAudioController.isListening)
        {
            if (helprinMovement.soldierSignal <= 1f)
            {
                helprinVoice.volume = 0.2f;
                noSignal.volume = 0.7f;
                badSignal.volume = 0.0f;
                goodSignal.volume = 0.0f;

                if (helprinMovement.inCombat)
                {
                    gunfire.volume = 0.2f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!helprinMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }

            if (helprinMovement.soldierSignal == 2f)
            {
                helprinVoice.volume = 0.5f;
                badSignal.volume = 0.7f;
                noSignal.volume = 0.0f;
                goodSignal.volume = 0.0f;

                if (helprinMovement.inCombat)
                {
                    gunfire.volume = 0.3f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!helprinMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }

            if (helprinMovement.soldierSignal >= 3f)
            {
                helprinVoice.volume = 0.8f;
                goodSignal.volume = 0.7f;
                noSignal.volume = 0.0f;
                badSignal.volume = 0.0f;
                if (helprinMovement.inCombat)
                {
                    gunfire.volume = 0.4f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!helprinMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }
        }

        if (isListening && captainAudioController.isListening)
        {
            if (captainMovement.soldierSignal <= 1f)
            {
                captainVoice.volume = 0.2f;
                noSignal.volume = 0.7f;
                badSignal.volume = 0.0f;
                goodSignal.volume = 0.0f;

                if (captainMovement.inCombat)
                {
                    gunfire.volume = 0.2f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!captainMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }

            if (captainMovement.soldierSignal == 2f)
            {
                captainVoice.volume = 0.5f;
                badSignal.volume = 0.7f;
                noSignal.volume = 0.0f;
                goodSignal.volume = 0.0f;

                if (captainMovement.inCombat)
                {
                    gunfire.volume = 0.3f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!captainMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }

            if (captainMovement.soldierSignal >= 3f)
            {
                captainVoice.volume = 0.8f;
                goodSignal.volume = 0.7f;
                noSignal.volume = 0.0f;
                badSignal.volume = 0.0f;
                if (captainMovement.inCombat)
                {
                    gunfire.volume = 0.4f;
                    combatAudio.volume = 0.1f;
                    heartbeat.volume = 0.9f;
                }
                if (!captainMovement.inCombat)
                {
                    gunfire.volume = 0.0f;
                    combatAudio.volume = 0.0f;
                    heartbeat.volume = 0.7f;
                }
            }
        }

        if (!isListening)
        {
            noSignal.volume = 0f;
            badSignal.volume = 0f;
            goodSignal.volume = 0f;
            captainVoice.volume = 0f;
            hellerVoice.volume = 0.0f;
            helprinVoice.volume = 0.0f;
            gunfire.volume = 0f;
            combatAudio.volume = 0f;
            heartbeat.volume = 0.7f;
        }
    }


    public void Voice001()
    {
        if (!isListening)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("001");
                isListening = true;
                captainAudioController.isListening = true;
            }
        }

        if (isListening)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                Debug.Log("001 Over");
                isListening = false;
                captainAudioController.isListening = false;
            }
        }
    }

    public void Voice002()
    {
        if (!isListening)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("002");
                isListening = true;
                hellerAudioController.isListening = true;
            }
        }

        if (isListening)
        {
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                Debug.Log("002 Over");
                isListening = false;
                hellerAudioController.isListening = false;
            }
        }
    }

    public void Voice004()
    {
        if (!isListening)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("004");
                isListening = true;
                helprinAudioController.isListening = true;
            }
        }

        if (isListening)
        {
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                Debug.Log("004 Over");
                isListening = false;
                helprinAudioController.isListening = false;
            }
        }
    }
}
