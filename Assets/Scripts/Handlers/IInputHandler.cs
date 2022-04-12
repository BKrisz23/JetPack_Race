/// <summary>
/// Interface for setting up 2 different inputHandlers:
/// 1. Player
/// 2. AI
/// </summary>
public interface IInputHandler
{
    bool IsTouch { get; }
}