using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //[SerializeField] private Animator anim;
    [SerializeField] protected Animator anim;
    [SerializeField] protected HealthBar healthBar;

    [SerializeField] private CombatText CombatTextPrefab;

    //private string currentAnimName;
    protected string currentAnimName;


    private float hp;
    
    public bool IsDead => hp <= 0; // "=>" tuong duong return

    //Ham OnInit giong ham khoi tao constructor, minh co the goi bat ki luc nao khong nhu constructor chi goi 1 lan

    //1 thg object ma chua cac thong so ma minh muon thay doi thi luon co 2 ham oninit va ondespawn

    private void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        hp = 100;
        healthBar.OnInit(100, transform);
    }
    //OnDespawn la ham huy? khi nao kcan dung 1 thg nao nua thi goi ham ondespawn de huy
    public virtual void OnDespawn()
    {

    }
   
    protected virtual void OnDeath()
    {
        ChangeAnim("Die");
        Invoke(nameof(OnDespawn), 2f);
    }

    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;
            
            if(IsDead)
            {
                hp = 0;
                OnDeath();
            }

            healthBar.SetNewHp(hp);
            Instantiate(CombatTextPrefab, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);

        }
    }
    
    //Tip: Thu tu cac ham muon ke thua thi de len tren
    //thu tu de cac ham Update(), Start() -> ke thua -> private -> bth
    //bien cua ham thi cac ham co constant -> serialized -> private -> public ( thg la getter setter )

    protected void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    

    
}
