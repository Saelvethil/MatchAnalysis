var AuthInterceptorService = function ($q, $location, SessionService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {
        config.headers = config.headers || {};
        var token = SessionService.getToken();
        if (token) {
            config.headers.Authorization = 'Bearer ' + token;
        }
        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            $location.path('/');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}

AuthInterceptorService.$inject = ['$q', '$location', 'SessionService'];