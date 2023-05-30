using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    int licznik;
    public Text scoreText;
    public Text winText;
    void Start()
    {
        AudioManager.instance.PlayMusic("music");
        rb2d = GetComponent<Rigidbody2D>();
        licznik = 0;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        /*if (moveHorizontal != 0 || moveVertical != 0)
        {
            AudioManager.instance.PlaySFX("move");
        }
        else
        {
            AudioManager.instance.Stop("move");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            AudioManager.instance.PlaySFX("pickup");
            Destroy(collision.gameObject);
            licznik++;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {licznik.ToString()}";
        if(licznik == 5)
        {
            winText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
        }    
    }
}
