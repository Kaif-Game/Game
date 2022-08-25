using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static int skin = 0;
    public Sprite[] sprites;

    private Animator animator;
    private Rigidbody2D rigidbody;
    [SerializeField] private AudioSource deathSound;

    private static int attemptCount = 1;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[skin];
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Block") || collision.name.Contains("Platform"))
            Die();
    }

    private void Die()
    {
        deathSound.Play();
        PlayerMovement.ChangePlaneCondion(false);
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void RestartLevel()
    {
        attemptCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    static public int GetAttemptCount()
    {
        return attemptCount;
    }
}
