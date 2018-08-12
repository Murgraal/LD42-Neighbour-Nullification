using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int Number;
    public GameObject HeldItem,Target;
    public Rigidbody rigid;
    public enum State {Default,Holding,Throwing,Interacting};
    public PlayerStats Stats;
    public PlayerMovement playerMovement;
    public PlayerUI playerUI;
    public SpawnShit spawnShit;
    public State state;

    private void Start()
    {
        Stats = GetComponent<PlayerStats>();
        playerMovement = GetComponent<PlayerMovement>();
        rigid = GetComponent<Rigidbody>();
        playerUI = GameObject.Find("Player" + Number + "UI").GetComponent<PlayerUI>();
        spawnShit = GetComponent<SpawnShit>();
    }

    private void Update()
    {
        playerMovement.CheckForInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            float x = collision.gameObject.GetComponent<Rigidbody>().velocity.x;
            float y = collision.gameObject.GetComponent<Rigidbody>().velocity.y;
            if (x > 3 || y > 3  || x < -3 || y < - 3)
            {
                print("gothere");
                rigid.AddForce((transform.position - collision.gameObject.transform.position).normalized * Stats.speed * 100);
            }
            
        } 
    }


    void FixedUpdate ()
    {
        playerMovement.MoveCharacter();
	}
}
