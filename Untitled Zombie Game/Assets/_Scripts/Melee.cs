using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public KeyCode MeleeAttackKey;

    int valueDamage;

    [SerializeField]
    public InformationValues informationValues;

    void Start()
    {
        Sword.SetActive(false);
        valueDamage = informationValues.damage._MeleeDamage;
        CanAttack = true;
    }

    void OnEnable()
    {
        Sword.SetActive(false);
        CanAttack = true;
    }

    void OnDisable()
    {
        Sword.transform.position = new Vector3(-0.171f, -0.025f, -0.659f);
    }

    void Update()
    {
        if (Input.GetKeyDown(MeleeAttackKey))
        {
            if (CanAttack)
            {
                
                SwordAttack();
            }
        }
    }


    public void SwordAttack()
    {
        Sword.SetActive(true);
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        Sword.SetActive(false);
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OutSide Collide");
        if (other.collider.tag == "Enemy")
        {
            Debug.Log("Enter if Statment");
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(valueDamage);
            if (health.currentHealth <= 0)
            {
                ScoreManager.instance.ChangeScore(150);
                ScoreManager.instance.DecreaseEnemy();
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            //Destroy(other.gameObject);
        }
    }

}
