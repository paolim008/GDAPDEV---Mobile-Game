using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CustomBullet : MonoBehaviour
{
    //Assignables
    [SerializeField] private int id;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask enemyMask;

    //Stats
    [Range(0f, 1f)] 
    private float bounciness;
    private bool useGravity;

    //Damage
    [SerializeField] private float explosionDamage;
    private float explosionRange;

    //Lifetime
    private int maxCollisions;
    private float maxLifetime;
    private bool explodeOnTouch = true;

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
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));


        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, enemyMask);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyAi>().TakeDamage(DamageEnemy(explosionDamage, enemies[i].GetComponent<EnemyAi>().id));
            }


        Invoke("Delay", 0.05f);
    }

    private float DamageEnemy(float explosionDamage, int enemyID)
    {
        float newExplosionDamage;
        newExplosionDamage = explosionDamage;

        if (enemyID == this.id)
        {
            //newExplosionDamage = newExplosionDamage * 2;
            return newExplosionDamage;
        }
        else
        {
            //newExplosionDamage = newExplosionDamage / 2;
            newExplosionDamage = 0;
        }

        return 0;
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Count up collisions
        collisions++;
        //Explode if bullet hits an enemy directly
            if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();



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

       
        switch (this.id)
        {
            case 0:     //Stats
                         bounciness = 0.8f;
                         useGravity = false;
                        //Damage
                         explosionDamage = 5;
                         explosionRange = 0.2f;
                        //Lifetime
                         maxCollisions = 0;
                         maxLifetime = 4;
                         explodeOnTouch = true;
                         break;

            case 1:     //Stats
                         bounciness = 0.8f;
                         useGravity = false;
                        //Damage
                         explosionDamage = 5;
                         explosionRange = 0.2f;
                        //Lifetime
                         maxCollisions = 0;
                         maxLifetime = 4;
                         explodeOnTouch = true;
                         break;

            case 2:     //Stats
                         bounciness = 0.8f;
                         useGravity = false;
                       //Damage
                         explosionDamage = 5;
                         explosionRange = 1f;
                       //Lifetime
                         maxCollisions = 1;
                         maxLifetime = 4;
                         explodeOnTouch = true;
                         break;
            case 3:     //Stats
                        bounciness = 0.8f;
                        useGravity = true;
                        //Damage
                        explosionDamage = 5;
                        explosionRange = 3f;
                        //Lifetime
                        maxCollisions = 1;
                        maxLifetime = 4;
                        explodeOnTouch = true;
                        break;
            default:
                break;
        }


}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

}
