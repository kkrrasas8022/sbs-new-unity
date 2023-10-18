using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    //�ʿ��Ѱ�
    //ĳ������ rigidbody component
    //ĳ������ collider
    //�������� �ӵ�
    //Ű �Է½� �������� ��
    //Ʈ���� �浹 ����

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
