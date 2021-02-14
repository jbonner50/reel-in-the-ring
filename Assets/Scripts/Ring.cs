using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ring : MonoBehaviour
{
    private bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying && won)
        {
            SceneManager.LoadScene("won");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hook(Clone)" && !won)
        {
            won = true;
            gameObject.GetComponent<AudioSource>().Play();

        }
        
    }
}
