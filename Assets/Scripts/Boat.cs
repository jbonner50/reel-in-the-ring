using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public GameObject fisherman;
    public Animator animator;
    public float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {


       
    }

    private void Update()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        animator.SetBool("Rowing", horizontal != 0);
        fisherman.GetComponent<SpriteRenderer>().flipX = horizontal < 0;

        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        float horizontalMin = -halfWidth;
        float horizontalMax = halfWidth;
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        if (transform.position.x + width / 2 > horizontalMax)
        {
            transform.position = new Vector3(horizontalMax - width/2, transform.position.y, transform.position.z);
        }
        else if (transform.position.x - width / 2 < horizontalMin)
        {
            transform.position = new Vector3(horizontalMin + width/2, transform.position.y, transform.position.z);

        }
        
    }
}
