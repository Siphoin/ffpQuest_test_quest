[System.Serializable]
public class ItemException : System.Exception
{
    public ItemException() { }
    public ItemException(string message) : base(message) { }
    public ItemException(string message, System.Exception inner) : base(message, inner) { }
    protected ItemException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}