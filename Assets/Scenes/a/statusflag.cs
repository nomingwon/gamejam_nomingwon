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
    Status s = Status.None; //enum �ʱ�ȭ ���� 0 �λ��� �����

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Add(Status.Poison);  //�ߵ����� �߰�
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Add(Status.Burn);  //ȭ�� �߰�
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Add(Status.Freeze); //�õ�����
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Add(Status.Regen); //���
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
            Debug.Log("���� ���� �쿩 �õ� ����");
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
        s = Status.None; //�����̻� �ʱ�ȭ
    }

    private void Heal()
    {
        if (Has(Status.Poison))
        {
            Remove(Status.Poison);
            Debug.Log("�ߵ� ����");
        }
        //�����ο� ����Ģ �����ϸ��.
    }

    private void Remove(Status x)
    {
        s = s & x;
    }

    private bool Has(Status x)
    {
        return (s & x) != 0; //��Ʈ AND ����
    }

    private void Add(Status x)
    {
        s = s | x; //��Ʈ OR ����
    }
}
