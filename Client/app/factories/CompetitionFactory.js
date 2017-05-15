var CompetitionFactory = function ($http, $q, SessionService) {
    return function () {
        var result = $q.defer();

        //var params = { grant_type: "password", userName: username, password: password };

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Competitions',
            headers: { 'Content-Type': 'application/json' }
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }
}

CompetitionFactory.$inject = ['$http', '$q', 'SessionService'];