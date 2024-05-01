using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private playerMoves playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    public float crawlSpeed = 2f; 
    private bool isCrawling = false; 
    private int crawlDirection = 1;

    private void Awake()
    {
        playerMovement = GetComponent<playerMoves>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();
        if (Input.GetMouseButton(1))
            Die();

        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            // Проверяем, нажата ли кнопка влево
            if (Input.GetKey(KeyCode.A))
            {
                isCrawling = true; // Устанавливаем флаг, что персонаж крадется
                crawlDirection = -1; // Устанавливаем направление движения влево
                GetComponent<Animator>().SetBool("isCrawling", true); // Устанавливаем соответствующее значение в аниматоре
            }
            // Проверяем, нажата ли кнопка вправо
            else if (Input.GetKey(KeyCode.D))
            {
                isCrawling = true; // Устанавливаем флаг, что персонаж крадется
                crawlDirection = 1; // Устанавливаем направление движения вправо
                GetComponent<Animator>().SetBool("isCrawling", true); // Устанавливаем соответствующее значение в аниматоре
            }
            else
            {
                isCrawling = false; // Сбрасываем флаг
                GetComponent<Animator>().SetBool("isCrawling", false); // Сбрасываем соответствующее значение в аниматоре
            }
        }
        else
        {
            isCrawling = false; // Сбрасываем флаг
            GetComponent<Animator>().SetBool("isCrawling", false); // Сбрасываем соответствующее значение в аниматоре
        }

        // Если персонаж крадется, двигаем его влево или вправо со скоростью crawlSpeed
        if (isCrawling)
        {
            transform.Translate(Vector3.right * crawlDirection * crawlSpeed * Time.deltaTime);
        }




        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    private void Die() 
    {
        anim.SetTrigger("die");
    }

}
