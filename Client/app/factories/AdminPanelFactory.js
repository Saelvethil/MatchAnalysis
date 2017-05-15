var AdminPanelFactory = function ($http, $q, SessionService) {
    var factory = {};

    factory.getUsers = function () {
        var result = $q.defer();

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/Account/Users/'
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    factory.remove = function(userId){
        var result = $q.defer();
        $http({
            method: 'DELETE',
            url: SessionService.apiUrl + '/api/Account/User/'+userId           
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    factory.save = function (userId, roleName) {
        var result = $q.defer();
        var data = { UserId: userId, RoleName: roleName };

        $http.put(
            SessionService.apiUrl + '/api/Account/User/',
            JSON.stringify(data),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        )        
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

AdminPanelFactory.$inject = ['$http', '$q', 'SessionService'];