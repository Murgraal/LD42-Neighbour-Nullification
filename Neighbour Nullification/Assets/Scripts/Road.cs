using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject bear;
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
           GameObject temp = Instantiate((GameObject)bear, new Vector3(Random.Range(collision.gameObject.transform.position.x-10, collision.gameObject.transform.position.x + 10), 0, 25), Quaternion.identity);
           temp.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - temp.transform.position).normalized * 500, ForceMode.Impulse);
        }
    }
}
