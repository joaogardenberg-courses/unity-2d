using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    Level level;
    SpriteRenderer spriteRenderer;
    int timesHit = 0;

    void Start() {
        level = FindObjectOfType<Level>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (tag == "Breakable") {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            int maxHits = hitSprites.Length;
            timesHit++;

            if (timesHit > maxHits) {
                DestroyBlock();
            } else {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite() {
        spriteRenderer.sprite = hitSprites[timesHit - 1];
    }

    private void DestroyBlock() {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        TriggerSparklesVFX();
        level.BlockDestroyed();
        FindObjectOfType<GameSession>().AddToScore();
    }

    private void PlayBlockDestroySFX() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
