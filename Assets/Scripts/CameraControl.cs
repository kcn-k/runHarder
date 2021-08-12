using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public PlayerMovement character;
    private Vector3 lastCharPosition;
    //var that moves camera according to characters last position
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<PlayerMovement>();

        lastCharPosition = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = character.transform.position.x - lastCharPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastCharPosition = character.transform.position;
    }
}
