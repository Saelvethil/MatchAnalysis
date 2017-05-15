var CreateReviewController = function ($scope, $location, $routeParams, ReviewFactory, FixtureFactory) {
    $scope.statusMessage = undefined;
    $scope.fixture = undefined;

    $scope.createForm = {
        title: undefined,
        body: undefined,
        prediction: undefined,
        fixtureId: $routeParams.fixtureId
    }

    $scope.create = function () {
        console.log($scope.createForm);
        ReviewFactory.create($scope.createForm)
        .then(function (response) {
            $scope.statusMessage = "Great! Review Created Successfully!";
            $scope.createForm = {
                title: undefined,
                body: undefined,
                prediction: undefined,
                fixtureId: $routeParams.fixtureId
            }
        }, function (response) {
            $scope.statusMessage = response.error_description;
        });
    }    

    $scope.getFixture = function (fixtureId) {
        FixtureFactory.getFixture(fixtureId)
        .then(function (response) {
            $scope.fixture = response;
        }, function (response) {
            $scope.statusMessage = response.Message;
            console.log(response);
        });
    }

    $scope.getFixture($routeParams.fixtureId);
}
CreateReviewController.$inject = ['$scope', '$location', '$routeParams', 'ReviewFactory', 'FixtureFactory'];