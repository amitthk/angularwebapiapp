using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularWebApiApp
{
    public static class BundleConfig
    {
        public static void RegisterBundles()
        {
            System.Web.Optimization.Bundle common_js_bundle = new System.Web.Optimization.Bundle("~/scripts/commonjqjs.bundle.js");

            common_js_bundle.Include("~/scripts/jquery.min.js");
            //<!-- 3rd party libraries -->

            common_js_bundle.Include("~/scripts/angular.min.js");
            common_js_bundle.Include("~/scripts/angular-route.min.js");
            common_js_bundle.Include("~/scripts/angular-local-storage.min.js");
            common_js_bundle.Include("~/scripts/modernizr-2.6.2-respond-1.1.0.min.js");

            //<!-- Load app main script -->
            common_js_bundle.Include("~/scripts/app/app.js");

            //<!-- Load services -->
            common_js_bundle.Include("~/scripts/app/services/authInterceptorService.js");
            common_js_bundle.Include("~/scripts/app/services/authService.js");
            common_js_bundle.Include("~/scripts/app/services/projService.js");
            common_js_bundle.Include("~/scripts/app/services/tokensManagerService.js");
            //<!-- Load controllers -->
            common_js_bundle.Include("~/scripts/app/controllers/topNavController.js");
            common_js_bundle.Include("~/scripts/app/controllers/indexController.js");
            common_js_bundle.Include("~/scripts/app/controllers/homeController.js");
            common_js_bundle.Include("~/scripts/app/controllers/loginController.js");
            common_js_bundle.Include("~/scripts/app/controllers/signupController.js");
            common_js_bundle.Include("~/scripts/app/controllers/projController.js");
            common_js_bundle.Include("~/scripts/app/controllers/refreshController.js");
            common_js_bundle.Include("~/scripts/app/controllers/tokensManagerController.js");


            System.Web.Optimization.BundleTable.Bundles.Add(common_js_bundle);


            System.Web.Optimization.Bundle min_angular_bundle = new System.Web.Optimization.Bundle("~/Scripts/min.angular.bundle.js");
            min_angular_bundle.Include("~/scripts/angular.min.js");
            min_angular_bundle.Include("~/scripts/angular-route.min.js");
            System.Web.Optimization.BundleTable.Bundles.Add(min_angular_bundle);

            System.Web.Optimization.Bundle app_css_bundle = new System.Web.Optimization.Bundle("~/content/css/app.bundle.css");
            //<!-- Bootstrap Core CSS -->
            app_css_bundle.Include("~/content/css/bootstrap.min.css");
            //<!-- Custom CSS -->
            app_css_bundle.Include("~/content/css/main.css");
            app_css_bundle.Include("~/content/css/custom.css");

            //<!-- Custom Fonts & Icons -->
            app_css_bundle.Include("~/content/css/fontfaces.css");
            app_css_bundle.Include("~/content/css/icomoon-social.css");
            app_css_bundle.Include("~/content/css/font-awesome.min.css");
            System.Web.Optimization.BundleTable.Bundles.Add(app_css_bundle);


            System.Web.Optimization.BundleTable.EnableOptimizations = true;
        }
    }
}