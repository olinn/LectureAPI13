app.controller('PageCtrl', function ($scope, Lecture, Comment) {

    $scope.lectures = Lecture.query();

    $scope.newLecture = function () {
        var lecture = new Lecture({ LectureTitle: $scope.newLectureTitle, LectureUrl: $scope.newLectureURL });
        lecture.$save(function (l) {
            $scope.lectures.push(l);
        });

        $scope.newLectureTitle = $scope.newLectureURL = '';
    };

    $scope.newComment = function (lecture, that) {
        console.log('adding comment', that, that.newCommentText, $scope);

        var comment = new Comment({ LectureID: lecture.ID, CommentText: that.newCommentText, Name: that.newCommentName });
        comment.$save(function (c) {
            console.log('comment added');
            lecture.comments.push(c);
        });

        that.newCommentText = that.newCommentName = '';
    };
});