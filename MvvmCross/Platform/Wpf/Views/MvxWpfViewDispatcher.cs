﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System.Windows.Threading;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Wpf.Views.Presenters;

namespace MvvmCross.Wpf.Views
{
    public class MvxWpfViewDispatcher
        : MvxWpfUIThreadDispatcher, IMvxViewDispatcher
    {
        private readonly IMvxWpfViewPresenter _presenter;

        public MvxWpfViewDispatcher(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher)
        {
            _presenter = presenter;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            return RequestMainThreadAction(() => _presenter.Show(request));
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            return RequestMainThreadAction(() => _presenter.ChangePresentation(hint));
        }
    }
}