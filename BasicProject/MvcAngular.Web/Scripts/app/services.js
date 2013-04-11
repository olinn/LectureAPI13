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
