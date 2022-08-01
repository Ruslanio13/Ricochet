using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport _twinTeleport;
    [SerializeField] private TeleportDirection _teleportDirection;
    private Player _player; 

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
            _twinTeleport.TeleportPlayer(collision.gameObject.GetComponent<Player>());
        }
    }

    public void TeleportPlayer(Player player)
    { 
        player.gameObject.transform.position = gameObject.transform.position;
        Vector2 newPlayerDirection = GetNewPlayerDirection(player.GetDirection());
        player.SetDirection(newPlayerDirection);
    }

    private Vector2 GetNewPlayerDirection(Vector2 pastPlayerDirection)
    {
        if (_twinTeleport._teleportDirection == _teleportDirection)
        {
            if (IsDirectionHorizontal())
                return new Vector2(-pastPlayerDirection.x, pastPlayerDirection.y);
            else
                return new Vector2(pastPlayerDirection.x, -pastPlayerDirection.y);
        }
        else if (IsTwinDirectionOpposite(_twinTeleport._teleportDirection))
        {
            return pastPlayerDirection;
        }
        else if (Mathf.Abs((int)_twinTeleport._teleportDirection - (int)_teleportDirection) == 2)
        {
            if (IsDirectionHorizontal())
                return new Vector2(-pastPlayerDirection.y, pastPlayerDirection.x);
            else
                return new Vector2(-pastPlayerDirection.y, -pastPlayerDirection.x);
        }
        else
        {
            if (IsDirectionHorizontal())
                return new Vector2(pastPlayerDirection.y, -pastPlayerDirection.x);
            else
                return new Vector2(pastPlayerDirection.y, pastPlayerDirection.x);
        }
    }

    private bool IsDirectionHorizontal() => (int)_teleportDirection < 2;

    private bool IsTwinDirectionOpposite(TeleportDirection twinTeleportDirection)
    {
        switch (twinTeleportDirection)
        {
            case TeleportDirection.RIGHT:
                return _teleportDirection == TeleportDirection.LEFT;
            case TeleportDirection.LEFT:
                return _teleportDirection == TeleportDirection.RIGHT;
            case TeleportDirection.UP:
                return _teleportDirection == TeleportDirection.DOWN;
            case TeleportDirection.DOWN:
                return _teleportDirection == TeleportDirection.UP;
            default:
                return false;
        }
    }
}
