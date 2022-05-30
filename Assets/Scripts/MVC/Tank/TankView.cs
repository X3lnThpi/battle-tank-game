using Assets.Scripts.MVC.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(PlayerMovement))]
public class TankView : MonoBehaviour, IDamagable
{
    public TankType tankType;
    private TankController tankController;
    private Image image;

    private TankState currentState;
    public TankPatrollingState patrollingState;
    public TankChasingState chasingState;
    [SerializeField]
    private List<TankState> tankStates;

    [SerializeField]
    private TankState startingState;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage"  );
        tankController.ApplyDamage(damage);
    }

    public void setTankControllerReference(TankController tankController)
    {
        this.tankController = tankController;
    }
    private void Start()
    {
        //Debug.Log("Tank View Created");
        //playerMovement.SetPlayerMovementReference(TankService);
        ChangeState(startingState);  
      
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
       // Debug.Log("View Class Update called");
    }

    public void ChangeColor(Color color)
    {
        image.color = color;
    }

    public void ChangeState(TankState newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }

        currentState = newState;
        currentState.OnEnterState();
    }
}
