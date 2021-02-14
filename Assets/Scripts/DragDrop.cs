using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour{

    public Line line;
    public bool isDragged = false;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isDragged = !isDragged;
        }
        if(isDragged)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        } else
        {
            transform.position = initialPos;
        }
    }



    //private void OnTriggerStay2D(Collision2D collision)
    //{
    //    Debug.Log("add bobber");
    //    if (collision.gameObject.name == "LineSegment(Clone)" && Input.GetKeyDown(KeyCode.Space))
    //    {
            
    //        line.addBobber(collision.gameObject);
            
    //    }
    //}


}
