var AdminPanelController = function ($scope, AdminPanelFactory) {
    $scope.statusMessage = undefined;
    $scope.users = [];

    $scope.loadData = function () {
        AdminPanelFactory.getUsers()
        .then(function (response) {
            $scope.users = response;
        }, function (response) {
            $scope.statusMessage = response.error_description;
        });
    }
    $scope.loadData();


    $scope.remove = function (userId) {
        var shouldRemove = confirm("Do you really want to remove user?");
        if (shouldRemove) {
            AdminPanelFactory.remove(userId)
            .then(function (response) {
                $scope.statusMessage = "Success!  User removed.";
            
                $scope.loadData();
            
            }, function (response) {
                $scope.statusMessage = response.error_description;
            });
        }

    }

    $scope.save = function (userId, roleName) {
        AdminPanelFactory.save(userId, roleName)
        .then(function (response) {
            $scope.statusMessage = "Success!  User edited and saved.";
        }, function (response) {
            $scope.statusMessage = response.error_description;
        });
    }

}
AdminPanelController.$inject = ['$scope', 'AdminPanelFactory'];