using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundList : MonoBehaviour
{
    [SerializeField]
    private ZoomedOutState zoomedOutState;  

    [SerializeField]
    private LevelBoundsCalculator[] levelBoundsCalculators;

    private void Start()
    {
        FindObjectOfType<SceneLevelHandler>().OnPlayerSetup += (transform) => FindPlayerBounds();

    }

    private void FindPlayerBounds()
    {
        LevelBoundsCalculator currentLevelBounds = null;
        for (int i = 0; i < levelBoundsCalculators.Length; i++)
        {
            if (levelBoundsCalculators[i].isActiveAndEnabled && levelBoundsCalculators[i].IsPlayerInBounds())
                currentLevelBounds = levelBoundsCalculators[i];
        }
        currentLevelBounds.OnPlayerEntered();
        currentLevelBounds.OnPlayerExited += FindPlayerBounds;
        zoomedOutState.LevelBounds = currentLevelBounds;
    }
}
