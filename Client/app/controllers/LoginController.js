var LoginController = function ($scope, $location, LoginFactory, SessionService, rootScope) {
    $scope.loginForm = {
        username: undefined,
        password: undefined,
        errorMessage: undefined
    };


    $scope.login = function () {
        LoginFactory.login($scope.loginForm.username, $scope.loginForm.password)
        .then(function (response) {
            SessionService.setToken(response.access_token);
            $location.path('/');

            LoginFactory.getRole($scope.loginForm.username)
            .then(function (response) {
                SessionService.setRole(response);
                SessionService.updateModel();
            }, function (response) {
                $scope.loginForm.errorMessage = response;
            });

        }, function (response) {
            $scope.loginForm.errorMessage = response.error_description;
        });
    }
}
LoginController.$inject = ['$scope', '$location', 'LoginFactory', 'SessionService', '$rootScope'];