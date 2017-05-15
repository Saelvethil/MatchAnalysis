var FixtureController = function ($scope, $location, $routeParams, FixtureFactory) {
    $scope.fixtures = [];
    $scope.statusMessage = undefined;
    
    var competitionId = $routeParams.competitionId;

    var getCompetitionFixtures = function () {
        FixtureFactory.getCompetitionFixtures(competitionId)
         .then(function (response) {
             $scope.fixtures = response;
             if ($scope.fixtures.length == 0)
                 $scope.statusMessage = 'There are no current fixtures';
         }, function (response) {
             $scope.statusMessage = response.error_description;
         });
    };
    getCompetitionFixtures();


}
FixtureController.$inject = ['$scope', '$location', '$routeParams', 'FixtureFactory'];