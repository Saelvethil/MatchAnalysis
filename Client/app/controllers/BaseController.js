
var BaseController = function ($scope, $location, SessionService) {

    $scope.SessionService = SessionService;

    $scope.models = {
        helloAngular: 'I work!'
    };

    $scope.logout = function () {
        SessionService.clearValues();
        SessionService.updateModel();
        $location.path('/');
    }

    $scope.navbarProperties = {
        isCollapsed: true
    };

}
// needs to be a string array equal to the controllers arguments
BaseController.$inject = ['$scope', '$location', 'SessionService'];