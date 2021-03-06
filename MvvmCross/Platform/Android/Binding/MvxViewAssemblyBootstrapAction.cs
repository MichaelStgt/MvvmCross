﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using Android.Views;
using MvvmCross.Binding.Droid.Binders.ViewTypeResolvers;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;

namespace MvvmCross.Binding.Droid
{
    public class MvxViewAssemblyBootstrapAction<TView>
        : IMvxBootstrapAction
    {
        public virtual void Run()
        {
            Mvx.CallbackWhenRegistered<IMvxTypeCache<View>>(RegisterViewTypes);
            Mvx.CallbackWhenRegistered<IMvxNamespaceListViewTypeResolver>(RegisterNamespace);
        }

        protected virtual void RegisterViewTypes()
        {
            var cache = Mvx.Resolve<IMvxTypeCache<View>>();
            cache.AddAssembly(typeof(TView).Assembly);
        }

        protected virtual void RegisterNamespace()
        {
            var resolver = Mvx.Resolve<IMvxNamespaceListViewTypeResolver>();
            resolver.Add(typeof(TView).Namespace);
        }
    }
}