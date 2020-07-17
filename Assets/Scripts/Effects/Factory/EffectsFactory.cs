using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;  

public class EffectsFactory : MonoBehaviour
{
   
    [SerializeField, Header("Effects")]
    private VisualEffect[] landEffects;
   
    private Transform effectParent;

    private void Awake(){
        effectParent = this.transform;
    }
    
    public VisualEffect Instantiate(EffectType effectType, Vector3 newPosition){

        VisualEffect effect = Instantiate(landEffects[(int)effectType], effectParent);
        effect.transform.position = newPosition;
        return effect;
    }
}
