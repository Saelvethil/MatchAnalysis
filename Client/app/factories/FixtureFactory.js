var FixtureFactory = function ($http, $q, SessionService) {
    var factory = {};

    factory.getCompetitionFixtures = function (competitionId) {
        var result = $q.defer();

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Fixtures/competitionId/' + competitionId,
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
    factory.getFixture = function (fixtureId) {
        var result = $q.defer();

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Fixtures/fixtureId/' + fixtureId,
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

    factory.getAllFixtures = function () {
        var result = $q.defer();

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Fixtures',
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

    return factory;
}

FixtureFactory.$inject = ['$http', '$q', 'SessionService'];