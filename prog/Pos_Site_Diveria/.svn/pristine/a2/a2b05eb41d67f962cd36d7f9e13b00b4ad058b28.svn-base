using System;
using Statetrust.Framework.Security.Core;
using Statetrust.Framework.Security.Core.Mvc;
[assembly: WebActivator.PostApplicationStartMethod(
    typeof($rootnamespace$.App_Start.STFMVCAppStart), "PostStart")]

namespace $rootnamespace$.App_Start {
    public static class STFMVCAppStart {
        public static void PostStart() {
            SecurityController.AutoRoute();
        }
    }
}