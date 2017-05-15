var Client = angular.module('Client', ['ngRoute', 'ngCookies']);

Client.controller('BaseController', BaseController);
Client.controller('LoginController', LoginController);
Client.controller('RegisterController', RegisterController);
Client.controller('CompetitionController', CompetitionController);
Client.controller('FixtureController', FixtureController);
Client.controller('FixturesSearchController', FixturesSearchController);
Client.controller('CreateReviewController', CreateReviewController);
Client.controller('ReviewController', ReviewController);
Client.controller('ReviewInfoController', ReviewInfoController);
Client.controller('RankingController', RankingController);
Client.controller('AdminPanelController', AdminPanelController);

Client.service('SessionService', SessionService);
Client.factory('AuthInterceptorService', AuthInterceptorService);

Client.factory('LoginFactory', LoginFactory);
Client.factory('RegisterFactory', RegisterFactory);
Client.factory('CompetitionFactory', CompetitionFactory);
Client.factory('CommentFactory', CommentFactory);
Client.factory('FixtureFactory', FixtureFactory);
Client.factory('ReviewFactory', ReviewFactory);
Client.factory('RankingFactory', RankingFactory);
Client.factory('AdminPanelFactory', AdminPanelFactory);

Client.filter('FixturesFilter', FixturesFilter);
Client.filter('UsersFilter', UsersFilter);

var configFunction = function ($routeProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthInterceptorService');
    $routeProvider.
        when('/login', {
            templateUrl: 'app/views/account/Login.html',
            controller: 'LoginController'
        })
        .when('/register', {
            templateUrl: 'app/views/account/Register.html',
            controller: 'RegisterController'
        })
        .when('/competitions', {
            templateUrl: 'app/views/Competitions.html',
            controller: 'CompetitionController'
        })
        .when('/fixtures/:competitionId', {
            templateUrl: 'app/views/Fixture/Fixtures.html',
            controller: 'FixtureController'
        })
        .when('/fixturesSearch', {
            templateUrl: 'app/views/Fixture/FixturesSearch.html',
            controller: 'FixturesSearchController'
        })
        .when('/createReview/:fixtureId', {
            templateUrl: 'app/views/Review/CreateReview.html',
            controller: 'CreateReviewController'
        })
        .when('/Review/:fixtureId', {
            templateUrl: 'app/views/Review/FixtureReviews.html',
            controller: 'ReviewController'
        })
        .when('/reviewInfo/:reviewId', {
            templateUrl: 'app/views/Review/ReviewInfo.html',
            controller: 'ReviewInfoController'
        })
        .when('/ranking', {
            templateUrl: 'app/views/Ranking.html',
            controller: 'RankingController'
        })
        .when('/adminpanel', {
            templateUrl: 'app/views/AdminPanel.html',
            controller: 'AdminPanelController'
        })
        .otherwise({
            redirectTo: '/competitions'
        });

}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

Client.config(configFunction);