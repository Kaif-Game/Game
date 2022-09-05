using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class PlayerLife : MonoBehaviour
{
    //private Animator animator;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private static int attemptCount = 1;

    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        //set sprite to player
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlayerLook.GetCurrentSprite();
        if(spriteRenderer.sprite == null)
        {
            Debug.Log("sprite is NULL");
        }

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
        if (collision.gameObject.name.Contains("Monster"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSound.Play();
        PlayerMovement.SetPlaneCondition(false);
        PlanePortal.isPlane = false;
        rigidbody.bodyType = RigidbodyType2D.Static;
        Invoke("RestartLevel", 1f);
        //animator.SetTrigger("death");
    }

    static public int GetAttemptCount()
    {
        return attemptCount;
    }

    static public void ResetAttemptCount()
    {
        attemptCount = 1;
    }

    private void RestartLevel()
    {
        attemptCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
