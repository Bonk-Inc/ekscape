using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField, Header("Main")]
    private EffectsFactory factory;

    [SerializeField, Header("Landing Particle")]
    private PlayerJump playerJump;
    [SerializeField]
    private Transform playerFeet;

    private void Start(){
        playerJump.OnLand += OnLandEffect;
    }

    private void OnLandEffect(){
        var newEffect = factory.Instantiate(EffectType.LandEffect, playerFeet.position);
    }

}
