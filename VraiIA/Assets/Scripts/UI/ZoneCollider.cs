using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollider : MonoBehaviour
{
    public ZoneStateMachine _machine;
    
   public void OnTriggerEnter(Collider other)
   {
        
        if(other.tag == "player1")
            {
                _machine.BlueCap = true;
            }
        else if(other.tag == "player2")
        {
            _machine.RedCap = true;
        }
        if(_machine.RedCap == true & _machine.BlueCap == true)
        {
            
        }
   }
   private void OnTriggerStay(Collider other)
   {
    if(_machine.BlueCap == true & other.tag == "player1" & _machine.RedCap != true)
    {
        
        
    }
    else if(_machine.RedCap == true & other.tag == "player2" & _machine.BlueCap != true)
    {
        
    }
   }
   private void OnTriggerExit(Collider other)
   {
        if(other.tag == "player1")
        {
            _machine.BlueCap = false;
        }
        else if(other.tag == "player2")
        {
            _machine.RedCap = false;
        }
   }
}
