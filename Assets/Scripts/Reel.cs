using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    private Line line;
    private int numSegments;
    private float timer = 0f;

    private void Awake()
    {
        line = transform.parent.GetComponent<Line>();
        numSegments = line.numSegments;
    }

    public void changeNumSegments(int num)
    {
        if(num > 0)
        {
            line.addSegment();
            numSegments++;
        } else if (num < 0)
        {
            line.removeSegment();
            numSegments--;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.S))
        {
            changeNumSegments(1);
        } else if(Input.GetKey(KeyCode.S))
        {
            timer += Time.deltaTime;
            if(timer > 0.5)
            {
                changeNumSegments(1);
                timer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            changeNumSegments(-1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                changeNumSegments(-1);
                timer = 0f;
            }
        }
    }
}
