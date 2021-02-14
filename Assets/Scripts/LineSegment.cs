using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSegment : MonoBehaviour
{
    public GameObject connectedAbove, connectedBelow;
    // Start is called before the first frame update
    void Start()
    {
        resetAnchor();
    }

    public void resetAnchor()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        LineSegment aboveSegment = connectedAbove.GetComponent<LineSegment>();

        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
