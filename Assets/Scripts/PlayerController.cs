using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public GameObject Coin;

    public float frwrdFrc = 1000f;
    public float sdwyFrc = 1000f;
    public float jmpFrc = 1000f;
    
    public int health = 5;

    private int score = 0;

    void FixedUpdate ()
    {
        if (Input.GetKey("w") )
        {
            rb.AddForce(0, 0, frwrdFrc * Time.deltaTime);
        }
        if (Input.GetKey("s") )
        {
            rb.AddForce(0, 0, -frwrdFrc * Time.deltaTime);
        }
        if (Input.GetKey("a") )
        {
            rb.AddForce(-sdwyFrc * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d") )
        {
            rb.AddForce(sdwyFrc * Time.deltaTime, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) ) 
        {
            rb.AddForce(0, jmpFrc * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (other.transform.tag == "Goal")
        {
            Debug.Log("You Win!");
        }

    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
           
           score = 0;
           health = 5;
           Invoke("Restart", 2f);
           Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
