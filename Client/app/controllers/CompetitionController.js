var CompetitionController = function ($scope, $location, CompetitionFactory) {
    $scope.competitions = [];
    $scope.statusMessage = undefined;

    var init = function () {
        CompetitionFactory()
         .then(function (response) {
             $scope.competitions = response;
         }, function (response) {
             $scope.statusMessage = response.error_description;
         });
    };
    init();


}
CompetitionController.$inject = ['$scope', '$location', 'CompetitionFactory'];