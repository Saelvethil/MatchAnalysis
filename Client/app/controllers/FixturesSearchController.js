var FixturesSearchController = function ($scope, $location, $routeParams, FixtureFactory) {
    $scope.fixtures = [];
    $scope.statusMessage = undefined;   

    var getAllFixtures = function () {
        FixtureFactory.getAllFixtures()
         .then(function (response) {
             $scope.fixtures = response;
             if ($scope.fixtures.length == 0)
                 $scope.statusMessage = 'There are no current fixtures';
         }, function (response) {
             $scope.statusMessage = response.error_description;
         });
    };
    getAllFixtures();


}
FixturesSearchController.$inject = ['$scope', '$location', '$routeParams', 'FixtureFactory'];