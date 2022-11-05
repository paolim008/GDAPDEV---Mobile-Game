using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLifetime : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0) Destroy(this.gameObject);
    }
}
