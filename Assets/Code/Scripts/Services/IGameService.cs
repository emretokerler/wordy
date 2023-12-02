namespace Wordy.Services
{
    public interface IGameService
    {
        void Initialize();
        bool IsInitialized { get; set;}
    }
}