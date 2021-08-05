[System.Serializable]
public class InventoryGridException : System.Exception
{
    public InventoryGridException() { }
    public InventoryGridException(string message) : base(message) { }
    public InventoryGridException(string message, System.Exception inner) : base(message, inner) { }
    protected InventoryGridException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}