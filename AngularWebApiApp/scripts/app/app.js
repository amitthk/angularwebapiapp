"use strict";

var appConstants = { jsBase:'/scripts/app' };

var app = angular.module('AngularWebApiApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: appConstants.jsBase+"/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: appConstants.jsBase+"/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: appConstants.jsBase+"/views/signup.html"
    });

    $routeProvider.when("/projects", {
        controller: "projController",
        templateUrl: appConstants.jsBase+"/views/projects.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: appConstants.jsBase+"/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: appConstants.jsBase+"/views/tokens.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://localhost:61528/',
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


