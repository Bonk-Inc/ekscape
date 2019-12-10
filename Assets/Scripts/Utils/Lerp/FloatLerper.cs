using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatLerper : Lerper<float>
{

    private float sizeCheck = 0.01f;

    public FloatLerper(float startValue, float endValue, float lerpSpeed, float sizeCheck) : base (startValue, endValue, lerpSpeed)
    {
        this.sizeCheck = sizeCheck;
    }

    public FloatLerper(float startValue, float endValue, float lerpSpeed) : base(startValue, endValue, lerpSpeed)
    {
    }

    public override IEnumerator LerpValue(Action<float> onUpdate, Action onFinish = null)
    {
        while (Math.Abs(CurrentValue - EndValue) > Math.Abs(sizeCheck))
        {
            Debug.Log(EndValue);
            CurrentValue = Mathf.Lerp(CurrentValue, EndValue, LerpSpeed * Time.deltaTime);
            onUpdate?.Invoke(CurrentValue);
            yield return null;
        }
        CurrentValue = EndValue;
        onUpdate.Invoke(CurrentValue);
        onFinish?.Invoke();
    }
}
