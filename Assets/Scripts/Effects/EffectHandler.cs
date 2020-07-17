using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField, Header("Main")]
    private EffectsFactory factory;

    private PlayerJump playerJump;
    private Transform playerFeet;

    private void Start(){
        playerJump = FindObjectOfType<PlayerJump>();
        playerFeet = GameObject.Find("Feet").transform;
        playerJump.OnLand += OnLandEffect;
    }

    private void OnLandEffect(){
        
        var newEffect = factory.Instantiate(EffectType.LandEffect, playerFeet.position);
    }

}
