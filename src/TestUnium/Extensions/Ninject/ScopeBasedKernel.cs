using System;
using System.Collections;
using System.Collections.Generic;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Blocks;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Syntax;

namespace TestUnium.Extensions.Ninject
{
    public class ScopeBasedKernel : IBindingRoot, IResolutionRoot
    {
        public IBindingToSyntax<T> Bind<T>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2> Bind<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3> Bind<T1, T2, T3>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3, T4> Bind<T1, T2, T3, T4>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<object> Bind(params Type[] services)
        {
            throw new NotImplementedException();
        }

        public void Unbind<T>()
        {
            throw new NotImplementedException();
        }

        public void Unbind(Type service)
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1> Rebind<T1>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2> Rebind<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3> Rebind<T1, T2, T3>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3, T4> Rebind<T1, T2, T3, T4>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<object> Rebind(params Type[] services)
        {
            throw new NotImplementedException();
        }

        public void AddBinding(IBinding binding)
        {
            throw new NotImplementedException();
        }

        public void RemoveBinding(IBinding binding)
        {
            throw new NotImplementedException();
        }

        public bool CanResolve(IRequest request)
        {
            throw new NotImplementedException();
        }

        public bool CanResolve(IRequest request, bool ignoreImplicitBindings)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Resolve(IRequest request)
        {
            throw new NotImplementedException();
        }

        public IRequest CreateRequest(Type service, Func<IBindingMetadata, bool> constraint, IEnumerable<IParameter> parameters, bool isOptional, bool isUnique)
        {
            throw new NotImplementedException();
        }

        public bool Release(object instance)
        {
            throw new NotImplementedException();
        }
    }
}




//protected override void AddComponents()
//{
//    base.AddComponents();
//}

//public override void Dispose(bool disposing)
//{
//    base.Dispose(disposing);
//}

//public override void Unbind(Type service)
//{
//    base.Unbind(service);
//}

//public override void AddBinding(IBinding binding)
//{
//    base.AddBinding(binding);
//}

//public override void RemoveBinding(IBinding binding)
//{
//    base.RemoveBinding(binding);
//}

//public override void Inject(object instance, params IParameter[] parameters)
//{
//    base.Inject(instance, parameters);
//}

//public override bool Release(object instance)
//{
//    return base.Release(instance);
//}

//public override bool CanResolve(IRequest request)
//{
//    return base.CanResolve(request);
//}

//public override bool CanResolve(IRequest request, bool ignoreImplicitBindings)
//{
//    return base.CanResolve(request, ignoreImplicitBindings);
//}

//public override IEnumerable<Object> Resolve(IRequest request)
//{
//    return base.Resolve(request);
//}

//public override IRequest CreateRequest(Type service, Func<IBindingMetadata, bool> constraint, IEnumerable<IParameter> parameters, bool isOptional, bool isUnique)
//{
//    return base.CreateRequest(service, constraint, parameters, isOptional, isUnique);
//}

//public override IActivationBlock BeginBlock()
//{
//    return base.BeginBlock();
//}

//public override IEnumerable<IBinding> GetBindings(Type service)
//{
//    return base.GetBindings(service);
//}

//protected override IComparer<IBinding> GetBindingPrecedenceComparer()
//{
//    return base.GetBindingPrecedenceComparer();
//}

//protected override Func<IBinding, bool> SatifiesRequest(IRequest request)
//{
//    return base.SatifiesRequest(request);
//}

//protected override bool HandleMissingBinding(Type service)
//{
//    return base.HandleMissingBinding(service);
//}

//protected override bool HandleMissingBinding(IRequest request)
//{
//    return base.HandleMissingBinding(request);
//}

//protected override bool TypeIsSelfBindable(Type service)
//{
//    return base.TypeIsSelfBindable(service);
//}

//protected override IContext CreateContext(IRequest request, IBinding binding)
//{
//    return base.CreateContext(request, binding);
//}

//public override string ToString()
//{
//    return base.ToString();
//}

//public override bool Equals(object obj)
//{
//    return base.Equals(obj);
//}

//public override int GetHashCode()
//{
//    return base.GetHashCode();
//}