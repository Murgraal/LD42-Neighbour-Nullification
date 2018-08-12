using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 dir;
    string horizontalInput, verticalInput;
    Player player;

    public void Start()
    {
        player = GetComponent<Player>();
        horizontalInput = "Horizontal" + player.Number;
        verticalInput = "Vertical" + player.Number;
    }

    public void CheckForInput()
    {
        float x = Input.GetAxisRaw(horizontalInput);
        float z = Input.GetAxisRaw(verticalInput);

        dir = new Vector3(x,0,z);
    }
    public void MoveCharacter()
    {
        player.rigid.AddForce(dir * player.Stats.speed);
    }
}
