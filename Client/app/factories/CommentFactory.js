var CommentFactory = function ($http, $q, SessionService) {
    var factory = {};

    factory.create = function (comment) {
        var result = $q.defer();
        $http({
            method: 'POST',
            url: SessionService.apiUrl + '/api/MainController/Comment',
            data: comment
        })
        .success(function (response) {
            result.resolve(response);
        })
        .error(function (response) {
            result.reject(response);
        });

        return result.promise;
    }

    factory.remove = function (commentId) {
        var result = $q.defer();
        $http({
            method: 'DELETE',
            url: SessionService.apiUrl + '/api/MainController/Comment/' + commentId
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

CommentFactory.$inject = ['$http', '$q', 'SessionService'];