using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private Movement _movement;
   [SerializeField] private PlayerAnim _playerAnim;

   private void Awake()
   {
      _movement.enabled = false;
   }

   public void EnablePlayer()
   {
      _movement.enabled = true;
   }
   private void Update()
   {
      _playerAnim.ToIdle();
      if (_movement.IsRunning)
      {
         _playerAnim.ToRun();
      }

      if (_movement.IsJumping)
      {
         _playerAnim.ToJump();
      }
   }
}
