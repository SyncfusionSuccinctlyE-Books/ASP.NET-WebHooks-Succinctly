/// <reference path="../angular.js" />

/// <reference path="app.js" />

app.controller('activityController', function($scope, activityService) {

    refreshGrid();

    function refreshGrid() {
        activityService.getAll().then(function(promise) { $scope.Activities = promise.data },
            function(err) {
                $log.error('error while connecting API', err);
            });
    };

    $scope.get = function(activityId) {
        activityService.get(activityId).then(function(promise) {
                $scope.Id = promise.ActivityId;
                $scope.Activity = promise.Activity;
                $scope.Action = promise.Action;
                $scope.Description = promise.Description;
                $scope.Data = promise.Data;
            },
            function(err) {
                $log.error('error while connecting API', err);
            });
    };


});