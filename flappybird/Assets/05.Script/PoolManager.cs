using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�������� �����ϰ� ���ӳ��� ������� ���� Ŭ����
public class PoolManager : MonoBehaviour
{
    //�ʿ��Ѱ�
    //�����յ��� �����ص� �ڷᱸ��
    //�������� ������ �Լ�

    //Ư�� �˻��� ���� �ڷᱸ�� - List
    [SerializeField]private List<GameObject> Prefabs;

    public GameObject Pooling(int index)
    {
        GameObject objects;

        objects = Prefabs[index];

        return objects;
    }
}
