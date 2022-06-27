using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jump = 5;
    private bool isGrounded = false;
    private Animator anim;
    public bool player = true;
    private Vector3 rotation;
    public GameObject camera;
    public AudioSource coinSound;
    public AudioSource jumpSound;
    public AudioSource dangerSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            anim.SetBool("IsRunning", true);
        }else
        {
            anim.SetBool("IsRunning", false);
        }

        if(!isGrounded){
            jumpSound.Play();
            anim.SetBool("IsJumping", true);
             
        }else{
            anim.SetBool("IsJumping", false);
            jumpSound.Stop();
        }

        if (direction < 0) {
            transform.eulerAngles = rotation - new Vector3(0,180,0);
            transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
        }
        if (direction > 0) {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpSound.Play();
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
        }
        
         camera.transform.position = new Vector3(transform.position.x , 0 , -10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Enemy") {
            // Instantiate(fire, transform.position , Quaternion.identity);
            // panel.SetActive(true);
            Destroy(collision.gameObject);
            // FindObjectOfType<AudioManager>().Play("Die");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Coin") {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
            Destroy(other.gameObject);
            coinSound.Play();
        }
        if (other.gameObject.tag == "danger") {
            dangerSound.Play();
            Destroy(rb);
            SceneManager.LoadScene("Menu");
        }

          if (other.gameObject.tag == "win") {
                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            SceneManager.LoadScene("Menu");
            PlayerPrefs.Save();
        }
    }
}
