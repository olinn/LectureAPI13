app.controller('PageCtrl', function ($scope, Lecture) {

    $scope.name = 'Kristjan!';

    $scope.lectures = Lecture.query();

});