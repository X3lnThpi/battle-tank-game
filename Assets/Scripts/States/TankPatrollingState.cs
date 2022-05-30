using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrollingState : TankState
{
    private float timeElapsed;
    public override void OnEnterState()
    {
        base.OnEnterState();
        tankView.ChangeColor(color);
        Debug.Log("Patrolling");
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed < 5f)
        {
            tankView.ChangeState(tankView.chasingState);
        }
    }
}
