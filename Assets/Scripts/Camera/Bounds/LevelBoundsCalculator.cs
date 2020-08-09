
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundsCalculator : MonoBehaviour
{

    [SerializeField]
    private Collider2D[] colliders;

    [SerializeField]
    private SpriteRenderer[] renderers;

    private PlayerJump playerTransform = null;
    private Coroutine checkBoundsRoutine = null;

    public Bounds currentLevelBounds { get; private set; }

    public event Action OnPlayerExited;
    public event Action<Bounds> OnBoundsUpdated;


    private void Awake()
    {
        UpdateBounds();
    }

    public void UpdateBounds()
    {
        currentLevelBounds = BoundsCalculationHelper.CalculateBounds2D(colliders, renderers);
        OnBoundsUpdated?.Invoke(currentLevelBounds);
    }

    public void OnPlayerEntered()
    {
        checkBoundsRoutine = StartCoroutine(CheckBounds());
    }

    public bool IsPlayerInBounds()
    {
        if (playerTransform == null)
            playerTransform = FindObjectOfType<PlayerJump>();
        return playerTransform != null && currentLevelBounds.Contains(playerTransform.transform.position);
    }

    private IEnumerator CheckBounds()
    {
        while (true)
        {
            if (!IsPlayerInBounds())
            {
                OnPlayerExited?.Invoke();
                OnPlayerExited = null;
                if (checkBoundsRoutine != null) StopCoroutine(checkBoundsRoutine);
            }
            yield return null;
        }
    }
}
