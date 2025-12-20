using System;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    
    void Awake()
    {
        if (!playerPrefab)
        {
            Debug.LogError($"{name}: {nameof(playerPrefab)} is required!", this);
        } else
        {
            var playerObject = Instantiate(playerPrefab, this.transform.position, this.transform.rotation);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.0f);
    }
}
