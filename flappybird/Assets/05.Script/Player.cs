using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    //필요한것
    //캐릭터의 rigidbody component
    //캐릭터의 collider
    //떨어지는 속도
    //키 입력시 가해지는 힘
    //트리거 충돌 유무

    private Rigidbody2D _rigid;
    [SerializeField]private float _jumpForce;

    public void Start()
    {
        transform.position = Vector3.zero;
        _rigid.velocity= Vector3.zero;
    }

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
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
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Death");
            GameManager.Instance.OnGameOver?.Invoke();
        }
        else if (collision.CompareTag("ScoreLine"))
        {
            Debug.Log("Plus");
            if (GameManager.Instance.OnScoreUp != null)
            {
                GameManager.Instance.OnScoreUp.Invoke();
            }
        }
    }

}
