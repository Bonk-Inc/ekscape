using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lerper<T>
{
    
    public T StartValue { get; set; }
    public T EndValue { get; set;  }
    public float LerpSpeed { get; set; }

    public T CurrentValue { get; protected set; }

    public Lerper(T startValue, T endValue, float lerpSpeed)
    {
        StartValue = startValue;
        EndValue = endValue;
        LerpSpeed = lerpSpeed;
    }

    public abstract IEnumerator LerpValue(Action<float> onUpdate, Action onFinish = null);

}
