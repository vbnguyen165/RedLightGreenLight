using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This class manages the behaviors of the Giant Doll.
// It is responsible for enabling the red light - green light feature of the game.
public class DollController : MonoBehaviour
{
    // Doll sounds
    [SerializeField] private AudioSource[] sounds;
    private AudioSource song;
    private AudioSource turnSound;

    // For determining whether the doll has turned approximately 360 degree.
    private float currentDirection;
    private float previousDirection;
    [SerializeField] float rotationSpeed = 80;

    [SerializeField] private GameObject trafficLights;
    private GameObject redLight;
    private GameObject greenLight;

    public GameObject player;
    private Animator playerAnimator;
    private AudioSource playerAudio;

    private float deadZone;

    [SerializeField] private GameObject winTextObject;
    [SerializeField] private TextMeshProUGUI remainingLightsText;

    private int remainingGreenLights;
    private const int MAX_GREEN_LIGHTS = 7;


    void Awake()
    {
        remainingGreenLights = MAX_GREEN_LIGHTS;
    }

    /*
     *  Start is called before the first frame update
     */
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        song = sounds[0];
        turnSound = sounds[1];
        // Game starts with Green Light
        song.Play();

        previousDirection = 0;

        playerAnimator = player.GetComponent<Animator>();
        playerAudio = player.GetComponent<AudioSource>();

        redLight = trafficLights.transform.GetChild(3).gameObject;
        greenLight = trafficLights.transform.GetChild(5).gameObject;
        redLight.SetActive(false);
        greenLight.SetActive(true);

        deadZone = GameObject.Find("Dead Zone").transform.position.z;

        SetGreenLightsText();
    }

    /*
     *  Edits the Text Mesh Pro object that displays the remaining number of green lights.
     */
    void SetGreenLightsText()
    {
        remainingLightsText.text = "Remaining Green Lights:  " + remainingGreenLights.ToString();
    }

    /*
     *  Update is called once per frame
     */
    void Update()
    {
        currentDirection = gameObject.transform.rotation.y;
        SetGreenLightsText();
        if (remainingGreenLights == 0 || player.gameObject.transform.position.z < deadZone)
        {
            if (!playerAnimator.GetBool("Dead"))
            {
                Kill();
            }
        }
        // Game only continues when neither player is dead nor player has won 
        if (!song.isPlaying && !playerAnimator.GetBool("Dead") && !winTextObject.activeInHierarchy)
        {

            // RED LIGHT
            if (currentDirection * previousDirection >= 0)
            {
                if (!redLight.activeInHierarchy)
                {
                    SwitchLights();
                }

                // Turn the doll around
                transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
                previousDirection = currentDirection;
                if (!turnSound.isPlaying)
                {
                    turnSound.Play();
                }

                // If player is moving during red light, shoot player
                if (playerAnimator.GetBool("isWalking"))
                {
                    Kill();
                }
            }
            // GREEN LIGHT (Doll has finished with one 360 degree turn)
            else
            {
                if (turnSound.isPlaying)
                {
                    turnSound.Stop();
                }
                song.Play();
                previousDirection = currentDirection;
                remainingGreenLights -= 1;
                SwitchLights();
            }
        }
    }

    /*
     *  Kills off player
     *  Precondition: Parameter Dead in the player animator must be false.
     */
    void Kill()
    {
        playerAnimator.SetBool("Dead", true);
        if (!playerAudio.isPlaying)
        {
            playerAudio.Play();
        }
    }

    /* 
     *  Switches the status of the traffic light. 
     *  If red light is on, turn it off and switch to green light.
     *  If green light is on, turn it off and switch to red light.
     */
    void SwitchLights()
    {
        redLight.SetActive(!redLight.activeInHierarchy);
        greenLight.SetActive(!greenLight.activeInHierarchy);
    }
}
