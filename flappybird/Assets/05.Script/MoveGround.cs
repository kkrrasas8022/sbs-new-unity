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
    [SerializeField]public PoolManager pool;
    [SerializeField] private GameObject _pipeUp;
    [SerializeField] private GameObject _pipeDown;
    [SerializeField] private GameObject _scoreLine;

    public void OnEnable()
    {
        Destroy(_pipeDown);
        Destroy(_pipeUp);
        Destroy(_scoreLine);
        GameObject newPipe;
        GameObject newLine;
        newPipe = pool.Pooling(1);
        _pipeDown = Instantiate(newPipe, 
            new Vector3(transform.position.x + 1.5f, Random.Range(4,7), 0), new Quaternion(0, 0, 0, 0), transform);
        newPipe = pool.Pooling(0);
        _pipeUp = Instantiate(newPipe,
            new Vector3(transform.position.x + 1.5f, Random.Range(-5,-3), 0), new Quaternion(0, 0, 0, 0), transform);
        newLine = pool.Pooling(2);
        _scoreLine = Instantiate(newLine,
            new Vector3(transform.position.x + 1.5f, 0, 0), new Quaternion(0, 0, 0, 0), transform);

    }   

    private void FixedUpdate()
    {
        transform.position = transform.position + Vector3.left * _moveSpeed * Time.fixedDeltaTime;
        if(transform.position.x < -6.4)
        {
            this.gameObject.SetActive(false);
            transform.position = new Vector3(6.3f, 0, 0);
            
            gameObject.SetActive(true);
        }
    }
}
