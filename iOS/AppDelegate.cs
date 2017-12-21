using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ICT13580100EndB.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var DbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            DbPath = System.IO.Path.Combine(DbPath, "Myshop.db3");

            LoadApplication(new App (DbPath)); 

            return base.FinishedLaunching(app, options);
        }
    }
}
