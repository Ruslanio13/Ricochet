using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport _twinTeleport;
    [SerializeField] private TeleportDirection _teleportDirection;
    [SerializeField] private Player _player;

    private enum TeleportDirection
    {
        RIGHT = 0,
        LEFT,
        UP,
        DOWN
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _twinTeleport.TeleportPlayer(_player);
        }
    }

    public void TeleportPlayer(Player player)
    { 
        player.gameObject.transform.position = gameObject.transform.position;
        Vector2 newPlayerDirection = GetNewPlayerDirection(player.GetDirection(), player);
        player.SetDirection(newPlayerDirection);
    }

    private Vector2 GetNewPlayerDirection(Vector2 pastPlayerDirection, Player player)
    {
        Vector2 newDirection = pastPlayerDirection;
        if (IsAngleRight())
        {
            newDirection = new Vector2(pastPlayerDirection.y, pastPlayerDirection.x);
        }

        switch (_teleportDirection)
        {
            case TeleportDirection.RIGHT:
                newDirection = new Vector2(Mathf.Abs(newDirection.x), newDirection.y);
                if (Mathf.Abs(newDirection.y) > .9f)
                    player.PushPlayer(Vector2.right * .2f);
                break;
            case TeleportDirection.LEFT:
                newDirection = new Vector2(-Mathf.Abs(newDirection.x), newDirection.y);
                if (Mathf.Abs(newDirection.y) > .9f)
                    player.PushPlayer(Vector2.left * .2f);
                break;
            case TeleportDirection.UP:
                newDirection = new Vector2(newDirection.x, Mathf.Abs(newDirection.y));
                if (Mathf.Abs(newDirection.x) > .9f)
                    player.PushPlayer(Vector2.up * .2f);
                break;
            case TeleportDirection.DOWN:
                newDirection = new Vector2(newDirection.x, -Mathf.Abs(newDirection.y));
                if (Mathf.Abs(newDirection.x) > .9f)
                    player.PushPlayer(Vector2.down * .2f);
                break;
        }
        return newDirection;
    }

    private bool IsAngleRight()
    {
        return ((Mathf.Abs((int)_twinTeleport._teleportDirection - (int)_teleportDirection) == 2)
            || (_twinTeleport._teleportDirection == TeleportDirection.RIGHT && _teleportDirection == TeleportDirection.DOWN)
            || (_twinTeleport._teleportDirection == TeleportDirection.DOWN && _teleportDirection == TeleportDirection.RIGHT)
            || (_twinTeleport._teleportDirection == TeleportDirection.LEFT && _teleportDirection == TeleportDirection.UP)
            || (_twinTeleport._teleportDirection == TeleportDirection.UP && _teleportDirection == TeleportDirection.LEFT));
    }
}
