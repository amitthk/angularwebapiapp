'use strict';
        app.factory('httpService', ['$q','$http', function ($q,$http) {
            var svc = {};

            svc.getUrl = function (urlToGet) {
                var deferred = $q.defer();
                var responsePromise = $http.get(urlToGet);
                responsePromise.success(function (data, status, headers, config) { deferred.resolve(data); });
                responsePromise.error(function (data, status, headers, config) { deferred.reject({ error: "Ajax Failed", errorInfo: data }); });
                return (deferred.promise);
            };

            svc.postUrl = function (urlToPost, postData) {
                var deferred = $q.defer();
                var responsePromise = $http.post(urlToPost, postData);
                responsePromise.success(function (data, status, headers, config) { deferred.resolve(data); });
                responsePromise.error(function (data, status, headers, config) { deferred.reject({ error: "Ajax Failed", errorInfo: data }); });
                return (deferred.promise);
            };

            return (svc);
        }]);