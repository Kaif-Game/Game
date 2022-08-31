using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;
    [SerializeField] private AudioSource deathSound;

    private static int attemptCount = 1;

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

    private void Die()
    {
        deathSound.Play();
        PlayerMovement.SetPlaneCondition(false);
        PlanePortal.isPlane = false;
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
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
