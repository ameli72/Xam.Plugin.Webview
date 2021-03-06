﻿using System.Runtime.InteropServices;

namespace Xam.Plugin.Abstractions.Events.Outbound
{
    [StructLayout(LayoutKind.Explicit)]
    public class WebViewControlEventAbstraction
    {
        [FieldOffset(0)]
        public WebViewControlEventStub Source;

        [FieldOffset(0)]
        public WebViewControlDelegate Target;
    }
}
