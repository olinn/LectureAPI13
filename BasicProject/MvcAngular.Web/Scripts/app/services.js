app
    .factory('Lecture', function ($resource) {
        return $resource('api/Lectures/:lectureId', { lectureId: '@ID' }, {
            update: { method: 'PUT' }
        });
    })

    .factory('Comment', function ($resource) {
        return $resource('api/Comments/:commentId', { commentId: '@ID' }, {
            update: { method: 'PUT' }
        });
    })

    .filter('timeAgo', function () {
        return function (input) {
            var pubAgo = Date.now() - new Date(input).getTime();

            var minSince = Math.floor(pubAgo / 60000);
            var hrsSince = Math.floor(minSince / 60);
            var daysSince = Math.floor(hrsSince / 24);

            if (daysSince > 0)
                return daysSince + ' days ago';
            else if (hrsSince > 0)
                return hrsSince + ' hours ago';
            else
                return minSince + ' minutes ago';
        }
    })
