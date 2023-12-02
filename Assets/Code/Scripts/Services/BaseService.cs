namespace Wordy.Services
{
    public abstract class BaseService : IGameService
    {
        public abstract void Initialize();
        public bool IsInitialized { get; set;}
    }
}