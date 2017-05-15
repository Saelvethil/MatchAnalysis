var ReviewController = function ($scope, $location, $routeParams, ReviewFactory, FixtureFactory) {
    $scope.statusMessage = undefined;
    $scope.reviews = [];
    $scope.fixture = undefined;

    var fixtureId = $routeParams.fixtureId;

    $scope.loadFixtureReviews = function (fixtureId) {
        ReviewFactory.getFixtureReviews(fixtureId)
        .then(function (response) {
            $scope.reviews = response;
            if ($scope.reviews.length == 0)
                $scope.statusMessage = 'There are no current reviews';
        }, function (response) {
            $scope.statusMessage = response.Message;
            console.log(response);
        });
    }

    $scope.getFixture = function (fixtureId) {
        FixtureFactory.getFixture(fixtureId)
        .then(function (response) {
            $scope.fixture = response;
        }, function (response) {
            $scope.statusMessage = response.Message;
        });
    }

    $scope.createReview = function (fixtureId) {
        $location.url('/createReview/' + fixtureId);
    }

    $scope.removeReview = function (reviewId, fixtureId) {
        ReviewFactory.remove(reviewId)
        .then(function (response) {
            $scope.loadFixtureReviews(fixtureId);
        }, function (response) {
            $scope.statusMessage = response.Message;            
        });
    }

    $scope.loadFixtureReviews(fixtureId);
    $scope.getFixture(fixtureId);

}
ReviewController.$inject = ['$scope', '$location', '$routeParams', 'ReviewFactory', 'FixtureFactory'];