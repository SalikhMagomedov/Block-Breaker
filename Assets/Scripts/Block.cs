﻿using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;

    private Level level;
    private GameStatus gameStatus;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start() => level.CountBreakableBlocks();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();

        Destroy(gameObject);
    }
}
