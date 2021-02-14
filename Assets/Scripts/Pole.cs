using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public GameObject boat;
    private Vector3 lockToBoat;
    // Start is called before the first frame update
    void Start()
    {
        lockToBoat = transform.position - boat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = boat.transform.position + lockToBoat;
    }

}
