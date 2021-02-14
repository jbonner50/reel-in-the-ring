using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fish : MonoBehaviour
{
    public Animator animator;
    private Vector2 mousePos;
    public float speed = 0.02f;
    private Rigidbody2D rb;
    private Vector2 position;
    private bool swimThru = false;
    private bool reset = false;

    public Texture2D cursorCollide;
    public Texture2D cursorSwimThru;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.SetCursor(cursorCollide, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying && reset)
        {
            SceneManager.LoadScene("default");
        }
        if (Input.GetMouseButtonDown(1))
        {
            swimThru = !swimThru;
            gameObject.layer = swimThru ? 9 : 0;
            Cursor.SetCursor(swimThru ? cursorSwimThru : cursorCollide, Vector2.zero, CursorMode.ForceSoftware);

        }
        //point
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(-1 * (mousePos.x - transform.position.x), -1 * (mousePos.y - transform.position.y));
        //flip
        transform.right = direction;
        GetComponent<SpriteRenderer>().flipY = direction.x < 0;

        position = Vector2.Lerp(transform.position, mousePos, speed);
    }

    private void LateUpdate()
    {
        
        if (Input.GetMouseButton(0))
        {
            
            rb.constraints = RigidbodyConstraints2D.None;
            rb.MovePosition(position);
            if (transform.position.x > Camera.main.pixelWidth / 2)
            {
                transform.position = new Vector3(Camera.main.pixelWidth / 2, transform.position.y, transform.position.z);
            }
            else if(transform.position.x < -1 * Camera.main.pixelWidth / 2)
            {
                transform.position = new Vector3(-1 * Camera.main.pixelWidth / 2, transform.position.y, transform.position.z);

            }
            
            
        }
        
        else
        {

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "Hook(Clone)" || collision.gameObject.name == "Hook" ) && !reset)
        {
            reset = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }


}
