using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //필요한것
    //캐릭터의 rigidbody component
    //캐릭터의 collider
    //떨어지는 속도
    //키 입력시 가해지는 힘
    //트리거 충돌 유무

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
