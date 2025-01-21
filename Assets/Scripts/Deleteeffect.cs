using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteeffect : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }
}
