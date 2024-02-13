using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] public FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;

    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;

    private int score = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value; scoreText.text = score.ToString();
            scoreEvent.RaiseEvent(Score);
        }
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }

    private void Start()
    {
        health.value = 50;
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    private void OnStartGame()
    {
        characterController.enabled = true;
    }

    public void TakeDamage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
        }
    }

    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();
    }

    public void ApplyDamage(float damage)
    {
        
    }
}