namespace TestUnium.Instantiation.Sessioning
{
    public interface ISessionPlugin
    {
        void OnStart(ISessionContext context);

        void OnEnd(ISessionContext context);
    }

    //public interface ISessionPlugin<in TSessionContext>
    //    where TSessionContext : ISessionContext
    //{
    //    void OnStart(TSessionContext context);

    //    void OnEnd(TSessionContext context);
    //}
}
