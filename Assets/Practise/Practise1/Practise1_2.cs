namespace Practise1
{
    /// Упражнение №2
    public interface IPlayerEventHandler
    {
        void OnPlayerJoined(Player player);
        void OnPlayerLeft(Player player);
    }

    public interface IHostMigrationHandler
    {
        void OnHostMigrationStarted(Host host);
        void OnHostMigrationEnded(Host host);
    }

    public interface INetworkObjectEventHandler
    {
        void OnNetworkObjectSpawned(NetworkObject obj);
        void OnNetworkObjectDestroyed(NetworkObject obj);
    }
    
    public class Player
    {
    }

    public class Host
    {
    }

    public class NetworkObject
    {
    }
}