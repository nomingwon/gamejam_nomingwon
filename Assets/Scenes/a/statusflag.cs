using System;
using UnityEditor.Rendering;
using UnityEngine;
public enum Status
    {
        None=0,
        Poison=1<<0,
        Burn=1<<1,
        Freeze=1<<2,
        Regen=1<<3,
    }
public class statusflag : MonoBehaviour
{
    float hp = 100f;
    Status s = Status.None; //enum 초기화 값이 0 인상태 만들기

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Add(Status.Poison);  //중독상태 추가
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Add(Status.Burn);  //화상 추가
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Add(Status.Freeze); //냉동상태
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Add(Status.Regen); //재생
        }

        if (Input.GetKeyDown(KeyCode.H))
            Heal();
        if (Input.GetKeyDown(KeyCode.C))
            ClearAll();
        if (Input.GetKeyDown(KeyCode.T))
            Tick();
        if (Input.anyKeyDown)
            Print();

    }

    private void Print()
    {
        string bin = Convert.ToString((int)s, 2).PadLeft(4, '0');
        Debug.Log($"HP = {hp}  Status ={s} bin = {bin}");
    }

    private void Tick()
    {
        if (Has(Status.Burn) && Has(Status.Freeze))
        {
            Remove(Status.Freeze);
            Debug.Log("불이 물을 녹여 냉동 해제");
        }
        if (Has(Status.Poison))
        {
            hp -= 5;
        }
        if (Has(Status.Burn))
        {
            hp -= 10;
        }
        if (Has(Status.Regen))
        {
            hp += 4;
        }
        hp = Mathf.Clamp(hp, 0, 100);

    }

    private void ClearAll()
    {
        s = Status.None; //상태이상 초기화
    }

    private void Heal()
    {
        if (Has(Status.Poison))
        {
            Remove(Status.Poison);
            Debug.Log("중독 해제");
        }
        //자유로운 힐규칙 생성하면됨.
    }

    private void Remove(Status x)
    {
        s = s & x;
    }

    private bool Has(Status x)
    {
        return (s & x) != 0; //비트 AND 연산
    }

    private void Add(Status x)
    {
        s = s | x; //비트 OR 연산
    }
}
