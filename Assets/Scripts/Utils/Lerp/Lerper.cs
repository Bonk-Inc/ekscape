using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lerper<T>
{

    public T StartValue;
    public T EndValue;
    public float LerpSpeed;

    public T CurrentValue { get; protected set; }

    public Lerper(T startValue, T endValue, float lerpSpeed)
    {
        StartValue = startValue;
        EndValue = endValue;
        LerpSpeed = lerpSpeed;
    }

    public abstract IEnumerator LerpValue(Action<float> onUpdate, Action onFinish = null);

}
