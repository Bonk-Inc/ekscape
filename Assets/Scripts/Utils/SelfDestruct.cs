using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    private float destructTime = 1;

    void Start()
    {
        StartCoroutine(DestructCoroutine());
    }

    private IEnumerator DestructCoroutine(){
        yield return new WaitForSeconds(destructTime);
        Destroy(gameObject);
    }
}
