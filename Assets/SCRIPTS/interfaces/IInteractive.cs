

using UnityEngine;

public interface IInteractive
{
    public GameObject gameObject { get; }
    public void Activate();
    public void Deactivate();
}
