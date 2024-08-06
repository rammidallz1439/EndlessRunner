using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{

    protected PlayerHandler Handler;

    public void SpawnPlatforms(GameObject player)
    {

        if (player.transform.position.z >= Handler.nextSpawnPoint)
        {
            GameObject platform = PoolManger.Instance.GetPooledObject("Platform");
            platform.transform.position = new Vector3(0, 0f, player.transform.position.z + 545);
            Handler.nextSpawnPoint += 845;


        }
        if (player.transform.position.z >= Handler.platformReturningCount)
        {
            // Game.EventManager.Instance.TriggerEvent(new PlatformReturningEvent());
            Handler.platformReturningCount += 900;
        }
    }

    protected void MoveRightEventHandler(MoveRightEvent e)
    {
        if (Handler.CurrentPositionIndex < Handler.Positions.Length - 1)
        {
            Handler.CurrentPositionIndex++;
        }
        UpdatePosition(e.Player);
    }

    protected void MoveLeftEventHandler(MoveLeftEvent e)
    {
        if (Handler.CurrentPositionIndex > 0)
        {
            Handler.CurrentPositionIndex--;
        }
        UpdatePosition(e.Player);
    }
    protected void PlayerJumpEventHandler(PlayerJumpEvent e)
    {
        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && Handler.IsGrounded)
        {
            Jump();
        }

        if (!Handler.IsGrounded)
        {
            ApplyGravity();
        }
    }


    public void SpawnPlatformEventHandler(SpawnPlatformEvent e)
    {
        SpawnPlatforms(e.player);
        e.onfinish.Invoke();

    }


    private void UpdatePosition(Transform player)
    {
        player.position = new Vector3(Handler.Positions[Handler.CurrentPositionIndex], player.position.y, player.position.z);
    }

    private void CheckGrounded()
    {
        Vector3 rayOrigin = Handler.player.transform.position;
        Vector3 rayDircetion = Vector3.down;

        RaycastHit hit;
        Handler.IsGrounded = Physics.Raycast(rayOrigin, rayDircetion, out hit, Handler.RayDistance, Handler.RayLayer);

        Color raycolor = Handler.IsGrounded ? Color.green : Color.red;
        Debug.DrawRay(rayOrigin, rayDircetion * Handler.RayDistance, raycolor);

        if (Handler.IsGrounded && Handler.VerticalVelocity < 0)
        {
            Handler.VerticalVelocity = 0f;
        }
    }

    private void Jump()
    {
        Handler.VerticalVelocity = Handler.JumpForce;
        Handler.player.transform.Translate(new Vector3(0, Handler.VerticalVelocity, 0));
    }

    private void ApplyGravity()
    {
        Handler.VerticalVelocity = Handler.Gravity * Time.deltaTime;
        Handler.player.transform.Translate(0, Handler.VerticalVelocity, 0);
    }
}
