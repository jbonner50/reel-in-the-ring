using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Rigidbody2D pole;
    public GameObject prefabHook;
    public GameObject prefabLineSegment;
    //public GameObject prefabBobber;
    public int numSegments = 5;

    public HingeJoint2D top;


    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D prevBody = pole;
        for (int i = 0; i < numSegments; i++)
        {
            
            GameObject newSegment = Instantiate(i == numSegments-1 ? prefabHook: prefabLineSegment);
            newSegment.transform.parent = transform;
            newSegment.transform.position = transform.position;
            newSegment.GetComponent<HingeJoint2D>().connectedBody = prevBody;
            
            prevBody = newSegment.GetComponent<Rigidbody2D>();

            if (i == 0)
            {
                top = newSegment.GetComponent<HingeJoint2D>();
            }
        }
        
    }

    public void addSegment()
    {
        GameObject newSegment = Instantiate(prefabLineSegment);
        newSegment.transform.parent = transform;
        newSegment.transform.position = transform.position;
        newSegment.GetComponent<HingeJoint2D>().connectedBody = pole;
        newSegment.GetComponent<LineSegment>().connectedBelow = top.gameObject;
        top.connectedBody = newSegment.GetComponent<Rigidbody2D>();
        top.GetComponent<LineSegment>().resetAnchor();
        top = newSegment.GetComponent<HingeJoint2D>();
        numSegments++;
    }


    public void removeSegment() {
        if (numSegments > 5)
        {
            GameObject hook = GameObject.Find("Hook(Clone)");
            HingeJoint2D bottom = hook.GetComponent<LineSegment>().connectedAbove.GetComponent<HingeJoint2D>();
            hook.GetComponent<HingeJoint2D>().connectedBody = bottom.GetComponent<LineSegment>().connectedAbove.GetComponent<Rigidbody2D>();
            hook.transform.position = bottom.gameObject.transform.position;
            hook.GetComponent<LineSegment>().resetAnchor();
            Destroy(bottom.gameObject);
            numSegments--;
        }
        
    }

    //public void addBobber(GameObject lineSegment)
    //{
    //    GameObject bobber = Instantiate(prefabBobber);
    //    bobber.transform.parent = transform;
    //    bobber.transform.position = lineSegment.transform.position;
    //    bobber.GetComponent<LineSegment>().connectedBelow = lineSegment.GetComponent<LineSegment>().connectedBelow;
    //    bobber.GetComponent<HingeJoint2D>().connectedBody = lineSegment.GetComponent<Rigidbody2D>();
    //    bobber.GetComponent<LineSegment>().connectedBelow.GetComponent<LineSegment>().connectedAbove = bobber;
    //    bobber.GetComponent<LineSegment>().connectedAbove.GetComponent<LineSegment>().connectedBelow = bobber;
    //    numSegments++;
    //}

    // Update is called once per frame
    void Update()
    {

        
    }
}
