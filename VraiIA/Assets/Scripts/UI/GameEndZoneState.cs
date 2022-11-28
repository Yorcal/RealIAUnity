using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndZoneState : BaseZoneState
{
    #region fileds

    #endregion

    #region Properties

    #endregion

    #region Methods   
    public override void StartState()
    {
      Debug.Log("FINITO Paco");
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.GAMEEND;
    }

    #endregion
}
