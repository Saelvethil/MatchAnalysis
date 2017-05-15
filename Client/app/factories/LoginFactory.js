var LoginFactory = function ($http, $q, SessionService) {
    var factory = {};

    factory.login = function (username, password) {
        var result = $q.defer();

        var params = { grant_type: "password", userName: username, password: password };
        $http({
            method: 'POST',
            url: SessionService.apiUrl + '/token',
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: params,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
        .success(function (response) {
            console.log(response);
            result.resolve(response);
            
        })
        .error(function (response) {
            console.log(response);
            result.reject(response);
           
        });

        return result.promise;
    }

    factory.getRole = function (username) {
        var result = $q.defer();
        var params = {
            userName: username
        };

        $http.post(SessionService.apiUrl + '/api/Account/UserRole/', '"' + username + '"')
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    return factory;
}

LoginFactory.$inject = ['$http', '$q', 'SessionService'];

//(function () {
//    'use strict';

//    var serviceId = 'LoginFactory';

//    angular.module('Client').factory(serviceId,
//        ['$http', '$q', SessionService, LoginFactory]);


//    function LoginFactory($http, $q, SessionService) {
//        function login(username, password) {
//            var result = $q.defer();

//            var params = { grant_type: "password", userName: username, password: password };

//            $http({
//                method: 'POST',
//                url: SessionService.apiUrl + '/token',
//                transformRequest: function (obj) {
//                    var str = [];
//                    for (var p in obj)
//                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
//                    return str.join("&");
//                },
//                data: params,
//                headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
//            })
//            .success(function (response) {
//                result.resolve(response);
//            })
//            .error(function (response) {
//                result.reject(response);
//            });

//            return result.promise;
//        }

//        function getRole(username) {
//            var result = $q.defer();

//            $http({
//                method: 'GET',
//                url: SessionService.apiUrl + '/api/account/userrole/' + username,
//                headers: { 'Content-Type': 'application/json;' }
//            })
//            .success(function (response) {
//                result.resolve(response);
//            })
//            .error(function (response) {
//                result.reject(response);
//            });

//            return result.promise;
//        }

//          var service = {
//              login: login,
//              getRole: getRole
//        };

//        return service;
//    }

//})();