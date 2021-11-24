using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the position of the main camera so that 
// it follows the Player with a fixed offset.
public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
