var app = angular.module('myApp', ['ngResource']);

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

        
        var minSince = Math.floor(pubAgo / 60000);
        var hrsSince = Math.floor(minSince / 60);
        var daysSince = Math.floor(hrsSince / 24);

        if (daysSince > 0)
            scope.lecture.PubDate = daysSince + ' days ago ';
        else if (hrsSince > 0 )
            scope.lecture.PubDate = hrsSince + ' hours ago';
        else if(minSince != 0)
            scope.lecture.PubDate = minSince + ' minutes ago';

        

        scope.$watch('lecture', function () {
            // Called when the scope is updated/changed. we need?
        });
    };
});
