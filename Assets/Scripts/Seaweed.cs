using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seaweed : MonoBehaviour
{
    private bool reset = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying && reset)
        {
            SceneManager.LoadScene("default");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Fish" && !reset)
        {
            reset = true;
            gameObject.GetComponent<AudioSource>().Play();

        }

    }
}

