using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
   
	public CharacterController PlayerHeight;
    public CapsuleCollider playerCol;
    public float normalHeight, crouchHeight;
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerHeight.height = crouchHeight;
            playerCol.height = crouchHeight;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            PlayerHeight.height = normalHeight;
            playerCol.height = normalHeight;
            player.position = player.position + offset;
        }
    }
}
