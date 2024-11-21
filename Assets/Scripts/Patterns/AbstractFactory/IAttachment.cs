using UnityEngine;

public interface IAttachment {
    public string ID { get; set; }
    public void AssembleAttachment();
    public void GetAttachment(IAttachment attachment);
}

public class Silencer : IAttachment {
    public string ID { get; set; }
    public void AssembleAttachment() {
        Debug.Log($"Silencer with id {ID} Assembled");
    }
    public void GetAttachment(IAttachment attachment) { }
}


public class Scope : IAttachment {
    public string ID { get; set; }
    public void AssembleAttachment() {
        Debug.Log($"Scope with id {ID} Assembled");
    }
    public void GetAttachment(IAttachment attachment) { }
}
