app.controller('PageCtrl', function ($scope, Lecture) {

    $scope.name = 'Kristjan!';

    $scope.lectures = Lecture.query();

    $scope.newLecture = function () {
        var lecture = new Lecture({ LectureTitle: $scope.newLectureTitle, LectureUrl: $scope.newLectureURL });
        lecture.$save(function (l) {
            $scope.lectures.push(l);
        });
    };
});