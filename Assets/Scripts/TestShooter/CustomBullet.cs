using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask enemyMask;

    //Stats
    [Range(0f, 1f)] 
    public float bounciness;
    public bool useGravity;

    //Damage
    public int explosionDamage;
    public float explosionRange;

    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    private int collisions;
    private PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //When to Explode
        if(collisions > maxCollisions) Explode();

        //Lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();


    }

    private void Explode()
    {
        //instantiate Explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, enemyMask);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyAi>().TakeDamage(explosionDamage);
        }

        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ////Dont count collisions with other bullets
        //if (collision.collider.CompareTag("Bullet")) return;

        //Count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly
        if (collision.collider.CompareTag("enemyMask") && explodeOnTouch) Explode();

    }

    private void Setup()
    {
        //Create a new physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        
        //Assign Material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //SetGravity
        rb.useGravity = useGravity;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

}
