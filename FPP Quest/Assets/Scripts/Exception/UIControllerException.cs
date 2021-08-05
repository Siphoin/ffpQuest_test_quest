[System.Serializable]
public class UIControllerException : System.Exception
{
    public UIControllerException() { }
    public UIControllerException(string message) : base(message) { }
    public UIControllerException(string message, System.Exception inner) : base(message, inner) { }
    protected UIControllerException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}