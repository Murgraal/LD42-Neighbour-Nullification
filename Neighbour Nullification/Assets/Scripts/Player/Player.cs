﻿using System.Collections;
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
    public State state;

    private void Awake()
    {
        Stats = GetComponent<PlayerStats>();
        playerMovement = GetComponent<PlayerMovement>();
        rigid = GetComponent<Rigidbody>();
        playerUI = GameObject.Find("Player" + Number + "UI").GetComponent<PlayerUI>();
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
            if (x > 1 || y > 1  || y < -1 || x < - 1)
            {
                rigid.AddForce(collision.transform.position - transform.position * Stats.speed * 30);
            }
            
        }
    }


    void FixedUpdate ()
    {
        playerMovement.MoveCharacter();
	}
}