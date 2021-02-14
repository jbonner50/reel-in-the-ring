using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LineSegment(Clone)")
        {
            gameObject.GetComponent<AudioSource>().Play();
            HingeJoint2D bottom = collision.gameObject.GetComponent<HingeJoint2D>();
            while (bottom.gameObject.name != "Hook(Clone)")
            {
                HingeJoint2D newBottom = bottom.gameObject.GetComponent<LineSegment>().connectedBelow.GetComponent<HingeJoint2D>();
                newBottom.connectedBody = bottom.GetComponent<LineSegment>().connectedAbove.GetComponent<Rigidbody2D>();
                newBottom.GetComponent<LineSegment>().connectedAbove = newBottom.connectedBody.gameObject;
                newBottom.connectedBody.GetComponent<LineSegment>().connectedBelow = newBottom.gameObject;
                newBottom.gameObject.transform.position = collision.gameObject.GetComponent<LineSegment>().connectedAbove.GetComponent<Rigidbody2D>().gameObject.transform.position;
                newBottom.GetComponent<LineSegment>().resetAnchor();
                
                Destroy(bottom.gameObject);
                bottom = newBottom;
            }
            
        }
    }
}
