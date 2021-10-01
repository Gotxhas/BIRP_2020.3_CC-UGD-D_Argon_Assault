using System;

public class EventBroker
{
    public static event Action<int> EnemyHit;

    public static void CallEnemyHit(int scorePoint)
    {
        EnemyHit?.Invoke(scorePoint);
    }
}
