var ReviewInfoController = function ($scope, $location, $routeParams, ReviewFactory, CommentFactory, FixtureFactory, RankingFactory, SessionService) {
    $scope.statusMessage = undefined;
    $scope.review = undefined;
    $scope.fixture = undefined
    $scope.rating = 5;
    $scope.ratingAvailable = undefined;
    $scope.newComment = {
        body: undefined,
        review: undefined
    }

    var reviewId = $routeParams.reviewId;

    $scope.loadReview = function (reviewId) {
        ReviewFactory.get(reviewId)
        .then(function (response) {
            console.log(response);
            $scope.review = response;

            FixtureFactory.getFixture(response.FixtureId)
            .then(function (response) {
                console.log(response);
                $scope.fixture = response;

                console.log("Logged? " + SessionService.isLoggedInEval());
                if (SessionService.isLoggedInEval()) {
                    RankingFactory.isAvailableToRate(reviewId)
                        .then(function (response) {
                            $scope.ratingAvailable = response;
                        }, function (response) {
                            $scope.statusMessage = response.Message;
                        }
                        );
                }


            }, function (response) {
                $scope.statusMessage = response.Message;
                console.log(response);
            });

        }, function (response) {
            $scope.statusMessage = response.Message;
            console.log(response);
        });
    }
    $scope.loadReview(reviewId);

    $scope.createComment = function () {
        console.log($scope.newComment);
        $scope.newComment.Review = $scope.review;
        CommentFactory.create($scope.newComment)
        .then(function (response) {
            $scope.newComment = {
                body: undefined,
                review: undefined
            }
            $scope.loadReview(reviewId);
        }, function (response) {
            $scope.statusMessage = response.error_description;
        });
    }

    $scope.removeComment = function (commentId) {
        console.log(commentId);
        CommentFactory.remove(commentId)
        .then(function (response) {
            $scope.loadReview(reviewId);
        }, function (response) {
            $scope.statusMessage = response.error_description;
        });
    }

    $scope.range = function (min, max, step) {
        step = step || 1;
        var input = [];
        for (var i = min; i <= max; i += step) {
            input.push(i);
        }
        return input;
    };

    $scope.rate = function () {
        $scope.ratingAvailable = false;
        console.log("rating: " + $scope.rating);
        RankingFactory.rate(reviewId, $scope.rating);
    }


}
ReviewInfoController.$inject = ['$scope', '$location', '$routeParams', 'ReviewFactory', 'CommentFactory', 'FixtureFactory', 'RankingFactory', 'SessionService'];