﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.Platform;

using MvvmCross.Platform.Mac.Views;
using MvvmCross.Platform.Logging;

namespace MvvmCross.Mac.Views
{
    public class MvxBindingViewControllerAdapter : MvxBaseViewControllerAdapter
    {
        protected IMvxMacView MacView
        {
            get { return ViewController as IMvxMacView; }
        }

        public MvxBindingViewControllerAdapter(IMvxEventSourceViewController eventSource)
            : base(eventSource)
        {
            if (!(eventSource is IMvxMacView))
                throw new ArgumentException(nameof(eventSource), $"{nameof(eventSource)} should be a {nameof(IMvxMacView)}");

            MacView.BindingContext = new MvxBindingContext();
        }

        public override void HandleDisposeCalled(object sender, EventArgs e)
        {
            if (MacView == null)
            {
                MvxLog.Instance.Warn($"{nameof(MacView)} is null for clearup of bindings");
                return;
            }
            MacView.ClearAllBindings();
            base.HandleDisposeCalled(sender, e);
        }
    }
}
