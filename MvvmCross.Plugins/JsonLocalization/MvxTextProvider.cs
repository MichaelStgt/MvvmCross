﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using MvvmCross.Localization;
using MvvmCross.Plugins.ResourceLoader;

namespace MvvmCross.Plugins.JsonLocalization
{
    public abstract class MvxTextProvider :
        MvxResourceProvider, IMvxTextProvider
    {
        #region Implementation of IMvxTextProvider

        public abstract string GetText(string namespaceKey, string typeKey, string name);

        public string GetText(string namespaceKey, string typeKey, string name, params object[] formatArgs)
        {
            var baseText = GetText(namespaceKey, typeKey, name);
            if (string.IsNullOrEmpty(baseText))
                return baseText;
            if (formatArgs.Length == 0)
            {
                return baseText;
            }
            return string.Format(baseText, formatArgs);
        }

        public abstract bool TryGetText(out string textValue, string namespaceKey, string typeKey, string name);

        public bool TryGetText(out string textValue, string namespaceKey, string typeKey, string name, params object[] formatArgs)
        {
            if (!TryGetText(out textValue, namespaceKey, typeKey, name)) return false;

            if (string.IsNullOrEmpty(textValue))
                return true;

            if (formatArgs.Length == 0)
            {
                return true;
            }

            textValue = string.Format(textValue, formatArgs);
            return true;
        }

        #endregion Implementation of IMvxTextProvider
    }
}