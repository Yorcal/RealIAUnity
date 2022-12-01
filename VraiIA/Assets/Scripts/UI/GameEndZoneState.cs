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
      _machine.EndMenu.SetActive(true);
      Time.timeScale = 0f;
      _machine.isPaused = true;
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
