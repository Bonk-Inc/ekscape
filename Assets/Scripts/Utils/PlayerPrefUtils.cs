using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefUtils : PlayerPrefs
{

    private const string boolKeyPrefix = "Boolean_";

    public static void SetBool(string key, bool value)
    {
        key = GetBoolKey(key);
        SetInt(key, BoolToIntBalue(value));
    }

    public static bool GetBool(string key)
    {
        key = GetBoolKey(key);
        int intValue = GetInt(key);
        return IntToBoolBalue(intValue);
    }

    private static bool IntToBoolBalue(int value)
    {
        return value > 1;
    }

    private static int BoolToIntBalue(bool value)
    {
        return value ? 1 : 0;
    }

    private static string GetBoolKey(string key)
    {
        return $"{boolKeyPrefix}{key}";
    }

}
