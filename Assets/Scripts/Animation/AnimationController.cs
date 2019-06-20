using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    public LifeManager Enemy;
    GameManager gameManager;
    Agent agent;
    Animator animator;

    #region Actions
    public Action Move, Attack, Ability, Stun, Damage, Happy, Death, Idle;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agent = GetComponentInParent<Agent>();
        animator = GetComponent<Animator>();
    }

    #region Funzioni MonoBehaviour
    private void OnEnable()
    {
        Death += DeathSetAnim;
        Happy += HappySetAnim;
        Move += MoveSetAnim;
        Idle += IdleSetAnim;
        Stun += StunSetAnim;
        Attack += AttackSetAnim;
        Ability += AbilitySetAnim;
        Damage += DamageSetAnim;
    }
    private void OnDisable()
    {
        Death -= DeathSetAnim;
        Happy -= HappySetAnim;
        Move -= MoveSetAnim;
        Idle -= IdleSetAnim;
        Stun -= StunSetAnim;
        Attack -= AttackSetAnim;
        Ability -= AbilitySetAnim;
        Damage -= DamageSetAnim;
    }
    #endregion

    #region Funzioni che settano i trigger
    private void MoveSetAnim()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            animator.SetTrigger("AnimWalk");
        }
    }
    private void HappySetAnim()
    {
        animator.ResetTrigger("AnimWalk");
        animator.SetTrigger("AnimHappyGeek");
    }
    private void AttackSetAnim()
    {
        animator.ResetTrigger("AnimWalk");
        animator.SetTrigger("AnimAttack");
    }
    private void AbilitySetAnim()
    {
        animator.ResetTrigger("AnimWalk");
        animator.SetTrigger("AnimAbility");
    }
    private void StunSetAnim()
    {
        animator.ResetTrigger("AnimWalk");
        animator.ResetTrigger("AnimStun");
        animator.SetTrigger("AnimStun");
    }
    private void DeathSetAnim()
    {
        animator.ResetTrigger("AnimWalk");
        animator.SetTrigger("AnimPlayDeathStranding");
    }
    private void IdleSetAnim()
    {
        if (!GetComponentInParent<Agent>().ImStunned)
        {
            animator.ResetTrigger("AnimWalk");
            animator.SetTrigger("AnimIdle"); 
        }
    }
    private void DamageSetAnim()
    {
        animator.ResetTrigger("AnimWalk");
        animator.SetTrigger("AnimDamage");
        if(agent.ImStunned)
        {
            Stun();
        }
    }
    #endregion

    #region Funzioni per animation events
    public void Idle_Animation()
    {
        GetComponentInParent<Agent>().OnAttack = false;
        Idle();
    }

    public void DamageEnemy()
    {
        if (Enemy != null)
        {
            Enemy.Damage();
        }
        Idle();
    }

    public void Stun_Animation()
    {
        Stun();
    }

    public void DieNow()
    {
        gameManager.EndGameCheck(agent.PlayerID, agent.gameObject);
    }

    #endregion
}
