using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoundsUpdater : MonoBehaviour
{

    [SerializeField]
    private LevelBoundsCalculator levelBounds;

    private void OnEnable()
    {
        levelBounds.UpdateBounds();
    }

    private void OnDisable()
    {
        levelBounds.UpdateBounds();
    }

}
