using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camerashake : MonoBehaviour
{
    public static camerashake Instance;

    private void Awake() => Instance = this;

    void Onshake(float duration,float strength)
    {
        transform .DOShakePosition(duration, strength);
        transform .DOShakeRotation(duration, strength); 
    }
   
    public static void shake(float duration,float strength)=>Instance.Onshake(duration, strength);
}
