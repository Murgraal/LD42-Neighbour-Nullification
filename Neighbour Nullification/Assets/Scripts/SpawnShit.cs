using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShit : MonoBehaviour {

    public GameObject[] shits;
    public Vector3 spawnpos;

    public void SpawnRandomShit ()
    {
        int r = Random.Range(0, shits.Length);
        Instantiate(shits[r], spawnpos, Quaternion.identity);
    }
}
