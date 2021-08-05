[System.Serializable]
public class DoorsListenerException : System.Exception
{
    public DoorsListenerException() { }
    public DoorsListenerException(string message) : base(message) { }
    public DoorsListenerException(string message, System.Exception inner) : base(message, inner) { }
    protected DoorsListenerException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}