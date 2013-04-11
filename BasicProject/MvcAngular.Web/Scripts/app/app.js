﻿var app = angular.module('myApp', ['ngResource']);

app.directive('lectureRepeatDirective', function ($http) {
    return function (scope, element, attrs) {

        scope.lecture.comments = [];

        var el = angular.element(element);
        el.bind('show', function (e) {
            //console.log("showing", attrs, scope.lecture, scope.lectures);

            $http.get('/api/Lectures/' + scope.lecture.ID + '/Comments').success(function (data, status, headers, config) {
                //console.log(data, status, headers, config);
                scope.lecture.comments = data;
            });
        });

        var pubAgo = Date.now() - new Date(scope.lecture.PubDate).getTime();
        scope.lecture.PubDate = Math.floor(pubAgo / 60000) + ' minutes ago';

        scope.$watch('lecture', function () {
            // Called when the scope is updated/changed. we need?
        });
    };
});
