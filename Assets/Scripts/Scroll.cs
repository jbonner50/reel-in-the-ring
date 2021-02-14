using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 0.1f;
    //public GameObject fish;
    //private Transform fishTransform;

    // Start is called before the first frame update
    void Start()
    {
        //fishTransform = fish.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.y = transform.position.y + speed * Input.mouseScrollDelta.y;
        transform.position = temp;
    }
}
