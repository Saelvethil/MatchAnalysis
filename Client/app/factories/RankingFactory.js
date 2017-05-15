var RankingFactory = function ($http, $q, SessionService) {
    var factory = {};

    factory.getRanking = function () {
        var result = $q.defer();
  
        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Ranking'
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    factory.isAvailableToRate = function (reviewId) {
        var result = $q.defer();

        $http({
            method: 'GET',
            url: SessionService.apiUrl + '/api/MainController/Rated/'+reviewId
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });
        return result.promise;
    }

    factory.rate = function (reviewId, rating) {
        var result = $q.defer();

        $http({
            method: 'POST',
            url: SessionService.apiUrl + '/api/MainController/Rating/' + reviewId+'/'+rating
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

RankingFactory.$inject = ['$http', '$q', 'SessionService'];