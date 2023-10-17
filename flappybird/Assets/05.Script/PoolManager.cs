using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//프리팹을 관리하고 게임내로 만들어줄 관리 클래스
public class PoolManager : MonoBehaviour
{
    //필요한것
    //프리팹들을 저장해둘 자료구조
    //프리팹을 내보낼 함수

    //특정 검색이 빠른 자료구조 - List
    [SerializeField]private List<GameObject> Prefabs;

    public GameObject Pooling(int index)
    {
        GameObject objects;

        objects = Prefabs[index];

        return objects;
    }
}
