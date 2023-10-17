using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ʿ��Ѱ�
    //ĳ������ rigidbody component
    //ĳ������ collider
    //�������� �ӵ�
    //Ű �Է½� �������� ��
    //Ʈ���� �浹 ����

    private Rigidbody2D _rigid;
    private CapsuleCollider2D _col;
    [SerializeField]private float _fallSpeed;
    [SerializeField]private float _jumpForce;
    [SerializeField]private bool _isCollision;
    

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _col= GetComponent<CapsuleCollider2D>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigid.velocity = Vector3.zero;
            _rigid.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Debug.Log("col");
        }
    }

}
