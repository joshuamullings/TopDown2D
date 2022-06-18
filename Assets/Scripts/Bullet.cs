using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float initialForce = 300.0f;

    [SerializeField] private float timeToFade = 2.0f;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private float fadeTimer = 0.0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            boxCollider2D.enabled = false;
            StartCoroutine(FadeAndDespawn());
        }
    }

    private IEnumerator FadeAndDespawn()
    {
        while (fadeTimer < timeToFade)
        {   
            UpdateAlpha();
            fadeTimer += Time.deltaTime;
            yield return null;
        }

        Destroy(this.gameObject);
        // testing
    }

    private void UpdateAlpha()
    {
        float oneMinusPercentageAlpha = 1 - (fadeTimer / timeToFade);
        spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            oneMinusPercentageAlpha
        );
    }
}
