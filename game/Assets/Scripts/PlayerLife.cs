using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private static int attemptCount = 1;

    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private Sprite[] appearenceSprites;

    private void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        backgroundMusic.Play();
        StartCoroutine(AppearenceAnimation());
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
        backgroundMusic.Stop();
        deathSound.Play();
        PlayerMovement.SetPlaneCondition(false); //set condition is not plane
        PlanePortal.isPlane = false;
        rigidbody.bodyType = RigidbodyType2D.Static; //stop cube moving
        StartCoroutine(DeathAnimation());
        Invoke("RestartLevel", 1f);
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

    private IEnumerator AppearenceAnimation()
    {
        for(int i = 0; i < appearenceSprites.Length; i++)
        {
            spriteRenderer.sprite = appearenceSprites[i];
            yield return new WaitForSeconds(.1f);
        }
        spriteRenderer.sprite = PlayerLook.GetCurrentSprite();
        spriteRenderer.color = PlayerLook.GetCurrentColor();
    }

    private IEnumerator DeathAnimation()
    {
        //same as appearence but in reverse order
        spriteRenderer.color = Color.white;
        for (int i = appearenceSprites.Length - 1; i >= 0; i--)
        {
            spriteRenderer.sprite = appearenceSprites[i];
            yield return new WaitForSeconds(.1f);
        }
        spriteRenderer.sprite = null;
    }
}
