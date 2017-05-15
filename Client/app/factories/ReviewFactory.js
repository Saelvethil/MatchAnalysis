var ReviewFactory = function ($http, $q, SessionService) {
    var factory = {};

    factory.get = function (reviewId) {
        var result = $q.defer();
        console.log(SessionService.apiUrl + '/api/MainController/Reviews/reviewId/' + reviewId);

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Reviews/reviewId/' + reviewId,
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

    factory.create = function (review) {
        var result = $q.defer();
        $http({
            method: 'POST',
            url: SessionService.apiUrl + '/api/MainController/Reviews',
            data: review
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    factory.remove = function (reviewId) {
        var result = $q.defer();
        $http({
            method: 'DELETE',
            url: SessionService.apiUrl + '/api/MainController/Reviews/' + reviewId
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    factory.getFixtureReviews = function (fixtureId) {
        var result = $q.defer();
        console.log(SessionService.apiUrl + '/api/MainController/Reviews/fixtureId/' + fixtureId);
        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Reviews/fixtureId/' + fixtureId,
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

ReviewFactory.$inject = ['$http', '$q', 'SessionService'];