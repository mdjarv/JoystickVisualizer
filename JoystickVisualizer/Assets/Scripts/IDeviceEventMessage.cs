using UnityEngine.EventSystems;

public interface IDeviceEventMessage: IEventSystemHandler
{
    void HandleEvent(string input, int value);
}
