app.factory('Lecture', function ($resource) {
    return $resource('api/Lectures/:lectureId', {}, {
        update: { method: 'PUT' }
    });
})