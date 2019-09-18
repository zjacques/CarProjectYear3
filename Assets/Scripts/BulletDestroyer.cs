using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}