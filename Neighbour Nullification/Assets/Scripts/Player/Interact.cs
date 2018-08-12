using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public List<GameObject> ObjectsClose;
    Player player;
    public float rotateSpeed,throwSpeed;
    string InteractKey;
    Rigidbody HoldItemRigid;
    Vector3 above;

	void Start ()
    {
        player = GetComponent<Player>();
        InteractKey = "Interact" + player.Number;
	}

    void PickupItem()
    {
            if (CheckForClosestObject() == null || CheckForClosestObject().tag != "CanBePickedUp")
            return;
            player.HeldItem = CheckForClosestObject();
            player.state = Player.State.Holding;
            HoldItemRigid = player.HeldItem.GetComponent<Rigidbody>();
            HoldItemRigid.isKinematic = true;
            player.HeldItem.transform.position = GetAbovePosition();
            player.HeldItem.transform.parent = transform;
    }

    void ThrowItem()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        if (Input.GetButtonDown(InteractKey))
        {
            Vector3 dir = player.Target.transform.position - transform.position;
            HoldItemRigid.isKinematic = false;
            HoldItemRigid.AddForce(dir * throwSpeed, ForceMode.Impulse);
            player.HeldItem.transform.parent = null;
            player.Target.SetActive(false);
            player.state = Player.State.Default;
        }
    }

    GameObject CheckForClosestObject()
    {
        if (ObjectsClose.Count < 1)
        {
            return null;
        }
        float cdistance,distance;
        GameObject ClosestObject = ObjectsClose[0];
        distance = Vector3.Distance(ObjectsClose[0].transform.position, transform.position);
        for (int i = 0; i < ObjectsClose.Count; i++)
        {
            cdistance = Vector3.Distance(ObjectsClose[i].transform.position, transform.position);

            if (cdistance < distance)
                ClosestObject = ObjectsClose[i];
        }
        return ClosestObject;
    }

    Vector3 GetAbovePosition()
    {
        Vector3 AboveCharacter = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
        return AboveCharacter;
    }

    private void OnTriggerEnter(Collider other)
    {
            ObjectsClose.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
            ObjectsClose.Remove(other.gameObject);
    }

    private void FixedUpdate()
    {
        if (player.state == Player.State.Throwing)
            ThrowItem();
    }

    void Update ()
    {
        if (Input.GetButtonDown(InteractKey))
        {
            if (player.state == Player.State.Default)
            {
                PickupItem();
                return;
            }
            else if (player.state == Player.State.Holding)
            {
                player.Target.SetActive(true);
                player.state = Player.State.Throwing;
            }
        }
           
    }
}
