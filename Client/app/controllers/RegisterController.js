var RegisterController = function ($scope, LoginFactory, RegisterFactory, SessionService) {
    $scope.registerForm = {
        username: undefined,
        password: undefined,
        confirmPassword: undefined,
        errorMessage: undefined
    };

    $scope.register = function () {
        RegisterFactory($scope.registerForm.username, $scope.registerForm.password, $scope.registerForm.confirmPassword)
        .then(function () {
            LoginFactory.login($scope.registerForm.username, $scope.registerForm.password)
            .then(function (response) {
                SessionService.setToken(response.access_token);

                LoginFactory.getRole($scope.registerForm.username)
                .then(function (response) {
                    SessionService.setRole(response);
                }, function (response) {
                    $scope.registerForm.errorMessage = response;
                });

            }, function (response) {
                $scope.registerForm.errorMessage = response;
            });
        }, function (response) {
            $scope.registerForm.errorMessage = response;
        });
    }
}
RegisterController.$inject = ['$scope', 'LoginFactory', 'RegisterFactory', 'SessionService'];