/// <reference path="../angular.js" />
/// <reference path="app.js" />
app.service("activityService", function($http) {
    'use strict';
    //Get Activities
    this.getAll = function() {
        return $http.get("api/Tracker");
    };

    //Get single activity

    this.getActivity = function(activityId) {
        return $http.get("api/Tracker/" + activityId);
    };
});