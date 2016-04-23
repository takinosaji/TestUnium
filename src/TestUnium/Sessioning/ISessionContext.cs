using Ninject;

namespace TestUnium.Sessioning
{
    public interface ISessionContext выбрать другое имя
    {
        void OnStart(IKernel kernel); а сюда принимать контекст в котором не только ядро будет

        void OnEnd(IKernel kernel);
    }
}
