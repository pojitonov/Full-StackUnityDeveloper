namespace Game.App
{
    public interface ISerializable
    {
    }

    public interface ISerializable<TSerializer> : ISerializable where TSerializer : IComponentSerializer
    {
    }
}