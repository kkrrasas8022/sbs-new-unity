using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    //필요한것
    //배경 이동 속도
    //배경 객체들을 저장하는 자료구조
    //배경이 재배치 되었는지 구분하는 bool
    [SerializeField]private float _moveSpeed;
    [SerializeField]private bool _isChange=false;
    [SerializeField]public PoolManager pool;
    [SerializeField] private GameObject _pipe;

    private void Update()
    {
        if (_isChange == true)
        {
            _pipe=pool.Pooling(Random.Range(0,2));
            Instantiate(_pipe, new Vector3(transform.position.x,Random.Range(0,6),0), new Quaternion(0, 0, 0, 0), transform);
            _pipe.transform.position = transform.position;
            _isChange= false;
        }
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + Vector3.left * _moveSpeed * Time.fixedDeltaTime;
        if(transform.position.x < -6.4)
        {
            transform.position = new Vector3(6.3f, 0, 0);
            _isChange = true;
        }
    }
}
