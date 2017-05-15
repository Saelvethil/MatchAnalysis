var RankingController = function ($scope, RankingFactory) {
    $scope.statusMessage = undefined;
    $scope.ranking = [];

    RankingFactory.getRanking()
    .then(function (response) {
        $scope.ranking = response;
    }, function (response) {
        $scope.statusMessage = response.error_description;
    });    
}
RankingController.$inject = ['$scope',  'RankingFactory'];