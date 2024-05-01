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
            // ���������, ������ �� ������ �����
            if (Input.GetKey(KeyCode.A))
            {
                isCrawling = true; // ������������� ����, ��� �������� ��������
                crawlDirection = -1; // ������������� ����������� �������� �����
                GetComponent<Animator>().SetBool("isCrawling", true); // ������������� ��������������� �������� � ���������
            }
            // ���������, ������ �� ������ ������
            else if (Input.GetKey(KeyCode.D))
            {
                isCrawling = true; // ������������� ����, ��� �������� ��������
                crawlDirection = 1; // ������������� ����������� �������� ������
                GetComponent<Animator>().SetBool("isCrawling", true); // ������������� ��������������� �������� � ���������
            }
            else
            {
                isCrawling = false; // ���������� ����
                GetComponent<Animator>().SetBool("isCrawling", false); // ���������� ��������������� �������� � ���������
            }
        }
        else
        {
            isCrawling = false; // ���������� ����
            GetComponent<Animator>().SetBool("isCrawling", false); // ���������� ��������������� �������� � ���������
        }

        // ���� �������� ��������, ������� ��� ����� ��� ������ �� ��������� crawlSpeed
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
