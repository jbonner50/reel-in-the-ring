using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startpos, speed = 0.05f;
    public Camera cam;
    [Range(0.0f, 1.0f)]
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {

        startpos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = cam.transform.position;
        temp.y = Mathf.Clamp(cam.transform.position.y + speed * Input.mouseScrollDelta.y, -25, 18);
        cam.transform.position = temp;

        float dist = cam.transform.position.y * parallaxEffect;
        temp = transform.position;
        temp.y = startpos + dist;
        transform.position = temp;
    }

    
}
